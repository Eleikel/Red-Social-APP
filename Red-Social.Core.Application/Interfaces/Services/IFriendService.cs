using Red_Social.Core.Application.ViewModels.Friends;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Services
{
    public interface IFriendService : IGenericService<SaveFriendViewModel, FriendViewModel, Friend>
    {
        Task<List<FriendViewModel>> GetAllViewModelWithInclude(int friendId);
        Task<bool> Exist(string category);
        Task<SaveFriendViewModel> GetFriendByIdSaveViewModel(int userId, int friendId);
        Task DeleteFriend(int userId, int friendId);

    }
}
