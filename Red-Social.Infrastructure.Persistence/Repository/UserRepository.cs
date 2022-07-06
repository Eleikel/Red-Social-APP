using Emarket.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public override async Task<User> AddAsync(User entity)
        {
            //Encryting password
            entity.Password = PasswordEncryption.ComputedSha256Hash(entity.Password);
            await base.AddAsync(entity); //Mantener la funcionalidad del padre (GenericRepository)
            return entity;
        }


        public override async Task UpdateAsync(User entity, int id)
        {
            //entity.Password = PasswordEncryption.ComputedSha256Hash(entity.Password);
            await base.UpdateAsync(entity, id); //Mantener la funcionalidad del padre (GenericRepository)
            //await _dbContext.SaveChangesAsync();
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryption.ComputedSha256Hash(loginVm.Password);

            User user = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.Username == loginVm.Username && user.Password == passwordEncrypt);
            return user;
        }


        public async Task<bool> ExistAync(string usuario)
        {
            return await _dbContext.Set<User>().AnyAsync(c => c.Username.ToLower().Trim() == usuario.ToLower().Trim());                      
        }
    }
}
