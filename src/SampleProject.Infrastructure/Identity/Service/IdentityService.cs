﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SampleProject.Application.Common.Exceptions;
using SampleProject.Infrastructure.Identity.Model;

namespace SampleProject.Infrastructure.Identity.Service
{
    public class IdentityService : Application.Common.Interfaces.IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser()
            {
                UserName = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Application.Common.Exceptions.ValidationException(result.Errors);
            }

            return (result.Succeeded, user.Id);
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            return await _userManager.GetUserIdAsync(user);
        }

        public async Task<bool> SigninUserAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return result.Succeeded;
        }
    }
}
