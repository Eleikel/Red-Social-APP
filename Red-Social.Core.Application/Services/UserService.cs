using Application.Services;
using AutoMapper;
using Red_Social.Core.Application.Dtos.Email;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel, UserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper, IEmailService emailService) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<bool> Exist(string user)
        {
            return await _userRepository.ExistAync(user);
        }

        public async Task<UserViewModel> Login(LoginViewModel loginVm)
        {
            User user = await _userRepository.LoginAsync(loginVm);

            if (user == null)
            {
                //Si user no trae datos es null
                return null;
            }

            UserViewModel userVm = _mapper.Map<UserViewModel>(user);

            return userVm;
        }

        public override async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            SaveUserViewModel userVm = await base.Add(vm);

            await _emailService.SendAsync(new EmailRequest
            {
                To = userVm.Email,
                Subject = $"Welcome {userVm.Name} to Red Social App",
                Body = $"<h1>Hello, </h1> <p>Your username is {userVm.Username}</p>" +
                $"Your Email Verification is <b>{userVm.Password}</b>"
            });

            return userVm;
        }

        public override async Task Update(SaveUserViewModel vm, int id)
        {
            //vm.Password = PasswordEncryption.ComputedSha256Hash(vm.Password);
            await base.Update(vm, id);

        }


        //entity.Password = PasswordEncryption.ComputedSha256Hash(entity.Password);




        public async Task<List<UserViewModel>> GetAllViewModeWithInclude()
        {

            var userList = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Post" });

            return userList.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                ProfilePhotoUrl = user.ProfilePhotoUrl,
                Email = user.Email,
                Phone = user.Phone,
                Username = user.Username,
                Password = user.Password
            }).ToList();
        }

        //public async Task AutoPassWordGenerate(RestorePasswordViewModel Vm)
        //{

        //    string newPassword = string.Empty;
        //    newPassword = Guid.NewGuid().ToString();

        //    await _emailService.SendAsync(new EmailRequest
        //    {
        //        To = Vm.Email,
        //        Subject = $"Welcome {Vm.Username} to Red Social App",
        //        Body = $"<h1>Hello, </h1> <p>Your username is {Vm.Username}</p>" +
        //         $"Your new Password is <b>{newPassword}</b>"
        //    });
        //}

        //public Task RestorePassword()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
