using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Repositories
{
    public interface IFriendRepository : IGenericRepository<Friend>
    {
        Task<bool> ExistAync(string usuario);


        Task<Friend> GetFriendAsync(int userId, int friendId);
    }
}
