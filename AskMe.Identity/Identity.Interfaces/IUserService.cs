using AskMe.Core.Core.Data.Entities;
using AskMe.Notifications.Notifications.Models;
using AskMe.Views.ViewModels;
using AthenicConsulting.Core.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AthenicConsulting.Identity.Identity.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> CreateUser(CreateAccountViewModel createAccountViewModel, RoleFlag roleFlag);
        Task<bool> CanSignIn(string email);
        Task<SignInResult> SignIn(SignInViewModel signInViewModel);
        Task SignOut();
        bool isUserSignedIn(ClaimsPrincipal claimsPrincipal);
        Task<bool> SendResetPasswordLink(SendEmailModel forgotPasswordViewModel);
        Task<bool> SendAccountCofirmationEmail(SendEmailModel accountConfirmation);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel);
        Task<IdentityResult> ConfirmEmail(string userId, string code);

    }
}
