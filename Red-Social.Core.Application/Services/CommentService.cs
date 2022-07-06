using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Domain.Entities;
using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Application.ViewModels;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Application.Helpers;

namespace Application.Services
{
    public class CommentService : GenericService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public override async Task<SaveCommentViewModel> Add(SaveCommentViewModel vm)
        {
            vm.UserId = userViewModel.Id;
            return await base.Add(vm);
        }

        public override async Task Update(SaveCommentViewModel vm, int id)
        {
            vm.UserId = userViewModel.Id;
            await base.Update(vm, id);
        }



        public async Task<List<CommentViewModel>> GetAllViewModelWithInclude()
        {
            var commentList = await _commentRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            //.Where(comment => comment.UserId == userViewModel.Id).
            return commentList.Select(comment => new CommentViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
                UserId = comment.UserId, //...
                PostId = comment.PostId
            }).ToList();
        }



    }
}
