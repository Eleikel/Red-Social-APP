using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Friends;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Services
{
    public class FriendService : GenericService<SaveFriendViewModel, FriendViewModel, Friend>, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        private readonly UserViewModel userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;



        public FriendService(IFriendRepository friendRepository, IHttpContextAccessor httpContextAccessor, IUserService userService, IMapper mapper) : base(friendRepository, mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _userService = userService;

        }

        public async Task<bool> Exist(string user)
        {
            return await _friendRepository.ExistAync(user);
        }

        public override async Task<SaveFriendViewModel> Add(SaveFriendViewModel vm)
        {
            vm.UserId = userViewModel.Id;
            return await base.Add(vm);
        }

        public override async Task Update(SaveFriendViewModel vm, int id)
        {
            vm.UserId = userViewModel.Id;
            await base.Update(vm, id);
        }




        public async Task<List<FriendViewModel>> GetAllFriend(int friendId)
        {
            var friendList = await _friendRepository.GetAllAsync();

            return friendList.Where(friend => friend.UserId == friendId).Select(friend => new FriendViewModel
            {
                Id = friend.Id,
                UserId = friend.User.Id,
                FriendId = friend.FriendId,
                FriendName = friend.Friendd.Username,
                FriendLastName = friend.Friendd.LastName
            }).ToList();
        }


        public async Task<SaveFriendViewModel> GetFriendByIdSaveViewModel(int userId, int friendId)
        {
            Friend friendById = await _friendRepository.GetFriendAsync(userId, friendId);
            SaveFriendViewModel vm = _mapper.Map<SaveFriendViewModel>(friendById);
            return vm;
        }


        public async Task DeleteFriend(int userId, int friendId)
        {
            Friend friendById = await _friendRepository.GetFriendAsync(userId, friendId);
            if (friendById != null)
            {
                await _friendRepository.DeleteAsync(friendById);
            }
            else
            {
                friendById = await _friendRepository.GetFriendAsync(friendId, userId);

                if (friendById != null)
                {
                    await _friendRepository.DeleteAsync(friendById);
                }
            }            
        }


        public async Task<List<FriendViewModel>> GetAllViewModelWithInclude(int userId)
        {            
            var friendList = await _friendRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            return friendList.Where(friend => friend.UserId == userId || friend.Id == userId).Select(friend => new FriendViewModel
            {
                Id = friend.Id,
                UserId = friend.User.Id,
                FriendId = friend.FriendId,
                FriendName = friend.Friendd.Name,
                FriendLastName = friend.Friendd.LastName,
                UserName = friend.Friendd.Username,
                PhotoProfile = friend.Friendd.ProfilePhotoUrl

            }).ToList();
        }

    }
}

