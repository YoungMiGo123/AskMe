using AskMe.Core.Core.Data.Entities;
using AskMe.Core.Core.Settings.Interfaces;
using AskMe.Notifications.Notifications.Interfaces;
using AskMe.Notifications.Notifications.Models;
using AskMe.Views.ViewModels;
using AthenicConsulting.Core.Core.Interfaces.Repositories;
using AthenicConsulting.Identity.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Web;

namespace AskMe.Identity.Identity.Models.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;
        private readonly IAskMeSettings _askMeSettings;
        public UserService(IUserRepository unitOfWork, INotificationService notificationService, IAskMeSettings askMeSettings)
        {
            _userRepository = unitOfWork;
            _notificationService = notificationService;
            _askMeSettings = askMeSettings;
        }

        public async Task<bool> CanSignIn(string email)
        {
            return await _userRepository.CanSignIn(email);
        }

        public async Task<IdentityResult> ConfirmEmail(string userId, string code)
        {
            var result = await _userRepository.ConfirmEmail(userId, code);
            return result;
        }

        public async Task<ApplicationUser> CreateUser(CreateAccountViewModel createAccountViewModel, RoleFlag roleFlag)
        {
            var user = await _userRepository.GetApplicationUserByEmail(createAccountViewModel.Email);
            if (user is null)
            {
                var createdUser = await _userRepository.CreateUser(createAccountViewModel);
                if (!createdUser.Succeeded)
                {
                    return user ?? new ApplicationUser();
                }
                user = await _userRepository.GetApplicationUserByEmail(createAccountViewModel.Email);

            }
            var isInRole = await _userRepository.IsUserInRole(user, roleFlag);
            if (!isInRole)
            {
                await _userRepository.AddUserToRoleAsync(user, roleFlag);
            }
            return user;
        }

        public bool isUserSignedIn(ClaimsPrincipal claimsPrincipal)
        {
            return _userRepository.IsSignIn(claimsPrincipal);
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            return await _userRepository.ResetPassword(resetPasswordViewModel);
        }

        public async Task<bool> SendAccountCofirmationEmail(SendEmailModel accountConfirmation)
        {
            var link = await _userRepository.GetAccountConfirmationLink(accountConfirmation.ToEmail);
            accountConfirmation.Body = $"Please confirm your account by clicking this link: <a href=\"{link}\">link</a><br/>";
            accountConfirmation.Body += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + link);
            accountConfirmation.FromEmail = _askMeSettings.FromEmail;
            var response = await _notificationService.SendEmailAsync(accountConfirmation);
            return !string.IsNullOrEmpty(response);
        }

        public async Task<bool> SendResetPasswordLink(SendEmailModel forgotPasswordViewModel)
        {
            var link = await _userRepository.GetResetPasswordCallbackUrl(new ForgotPasswordViewModel { Email = forgotPasswordViewModel.ToEmail });
            forgotPasswordViewModel.Body = $"Please reset your password by clicking here: <a href=\"{link}\">link</a>";
            forgotPasswordViewModel.Body += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + link);
            forgotPasswordViewModel.FromEmail = _askMeSettings.FromEmail;
            var response = await _notificationService.SendEmailAsync(forgotPasswordViewModel);
            return !string.IsNullOrEmpty(response);
        }

        public async Task<SignInResult> SignIn(SignInViewModel signInViewModel)
        {
            return await _userRepository.SignIn(signInViewModel);
        }

        public async Task SignOut()
        {
            await _userRepository.SignOut();
        }

    }
}
