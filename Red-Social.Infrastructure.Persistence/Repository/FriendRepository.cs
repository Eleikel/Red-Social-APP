using Emarket.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Infrastructure.Persistence.Repository
{
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {

        private readonly ApplicationContext _dbContext;


        public FriendRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> ExistAync(string usuario)
        {
            throw new NotImplementedException();
        }


        public override async Task<Friend> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Friend>().FindAsync(id);
        }

        public async Task<Friend> GetFriendAsync(int userId, int friendId)
        {
            return await _dbContext.Set<Friend>().FirstOrDefaultAsync(friend => friend.UserId == userId && friend.FriendId == friendId);
        
        }





    }
}
