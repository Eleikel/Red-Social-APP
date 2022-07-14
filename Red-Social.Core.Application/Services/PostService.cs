using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;

using Red_Social.Core.Application.Dtos.Email;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;



        public PostService(IPostRepository postRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IUserService userService) : base(postRepository, mapper)
        {
            _userService = userService;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");


        }

        public override async Task<SavePostViewModel> Add(SavePostViewModel vm)
        {
            vm.UserId = userViewModel.Id;
            vm.Created = DateTime.Now;
            return await base.Add(vm);
        }

        public override async Task Update(SavePostViewModel vm, int id)
        {
            vm.Created = DateTime.Now;
            vm.UserId = userViewModel.Id;
            await base.Update(vm, id);
        }

        public override async Task<List<PostViewModel>> GetAllViewModel()
        {
            var postList = await _postRepository.GetAllWithIncludeAsync(new List<string> { "User" });
            await base.GetAllViewModel();

            return postList.Where(post => post.UserId == userViewModel.Id).OrderByDescending(c => c.Id).Select(post => new PostViewModel
            {
                Id = post.Id,
                Text = post.Text,
                ImageUrl = post.ImageUrl,
                UserId = post.User.Id,
                UserName = post.User.Name,
                UserPhoto = post.User.ProfilePhotoUrl,
                Created = post.Created,                
            }).ToList();
        }


        public async Task<List<PostViewModel>> GetPostList(int id)
        {
            var postList = await _postRepository.GetAllWithIncludeAsync(new List<string> { "User"});
            var IdList = await _userService.GetByIdWithFriends(id);
            List<Post> posts = new List<Post>();

            foreach (var item in IdList)
            {
                posts.AddRange(postList.Where(post => post.UserId == item));
            }

             posts = posts.OrderByDescending(post => post.Created).ToList();

            return _mapper.Map<List<PostViewModel>>(posts);
        }





        //Obtener los Post de los amigos
        public async Task<List<PostViewModel>> GetAllViewModelWithInclude(int friendId)
        {
            var postList = await _postRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            //var usuarioActual = await _userRepository.GetByIdAsync(userViewModel.Id);


            return postList.Where(friend => friend.UserId == friendId).Select(post => new PostViewModel
            {
                Id = post.Id,
                Text = post.Text,
                ImageUrl = post.ImageUrl,
                UserId = post.User.Id,
                UserName = post.User.Name,
                UserPhoto = post.User.ProfilePhotoUrl,
                Created = post.Created,
                
            }).ToList();
        }

    }
}
