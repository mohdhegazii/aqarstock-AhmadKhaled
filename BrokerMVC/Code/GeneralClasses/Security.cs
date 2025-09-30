using BrokerMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrokerMVC.Code.Repositories;

namespace BrokerMVC
{
    public static class Security
    {
        public static ValidationResult ValidateUser(string username, string password)
        {
            var validationResult = new ValidationResult();
            // Instantiate a new ApplicationUserManager and find a user based on provided Username
            var userManager = new UserManager();
            var user = userManager.FindByName(username);

            // Invalid user, fail login
            if (user == null || userManager.IsLockedOut(user.Id))
            {
                // Do something here to tell the user
                validationResult.IsValid = false;
                validationResult.Message = Messages.UserNameNotExsit;
                return validationResult;
            }

            // Valid user, verify password
            var result = userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
            {
                UserAuthenticated(userManager, user);
                validationResult.IsValid = true;
                return validationResult;
            }
            else if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                // Logged in using old Membership credentials - update hashed password in database
                // Since we update the user on login anyway, we'll just set the new hash
                // Optionally could set password via the ApplicationUserManager by using
                // RemovePassword() and AddPassword()
                user.PasswordHash = userManager.PasswordHasher.HashPassword(password);
                UserAuthenticated(userManager, user);
                validationResult.IsValid = true;
                return validationResult;
            }
            else
            {
                // Failed login, increment failed login counter
                // Lockout for 15 minutes if more than 10 failed attempts
                user.AccessFailedCount++;
                if (user.AccessFailedCount >= 10) user.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(15);
                userManager.Update(user);
                // Do something here to tell the user
                validationResult.IsValid = false;
                validationResult.Message = Messages.InvalidPassword;
                return validationResult;
            }
        }
        private static void UserAuthenticated(UserManager userManager, ApplicationUser user)
        {
            // Create an instance of an AuthenticationManager and Identity to authenticate and sign in the user
            // If all goes well, redirect the user to either the querystring's return URL, or their account
            var authenticationManager = HttpContext.Current.Request.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
            user.AccessFailedCount = 0;
            user.LockoutEndDateUtc = null;
            userManager.Update(user);
            //  Response.Redirect(Request.QueryString["ReturnUrl"] ?? "~/Account/");
        }
        public static bool IsUserInRole(Roles role)
        {
            bool result = false;
            ApplicationDbContext context = new ApplicationDbContext();
            var RoleM = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            var u = um.FindByName(HttpContext.Current.User.Identity.Name);
            if (um.IsInRole(u.Id, role.ToString()))
            {
                result = true;
            }
            return result;
        }
        public static bool IsUserInRole(string username, Roles role)
        {
            bool result = false;
            ApplicationDbContext context = new ApplicationDbContext();
            var RoleM = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            var u = um.FindByName(username);
            if (um.IsInRole(u.Id, role.ToString()))
            {
                result = true;
            }
            return result;
        }
        public static bool RemoveUserFromRole(string username, Roles role)
        {
            bool result = false;
            ApplicationDbContext context = new ApplicationDbContext();
            var RoleM = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            var u = um.FindByName(username);
            if (um.IsInRole(u.Id, role.ToString()))
            {
                um.RemoveFromRole(u.Id, role.ToString());
                result = true;
            }
            return result;
        }
        public static bool AddUserToRole(string username, Roles role)
        {
            bool result = false;
            ApplicationDbContext context = new ApplicationDbContext();
            var RoleM = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            var u = um.FindByName(username);
            if (!um.IsInRole(u.Id, role.ToString()))
            {
                um.AddToRole(u.Id, role.ToString());
                result = true;
            }
            return result;
        }

        public static bool CreateUser(Subscriber subscriber)
        {
            var userManager = new UserManager();
            ApplicationUser user = new ApplicationUser();
            user.Email = subscriber.Email;
            user.PhoneNumber = subscriber.MobileNo;
            user.UserName = subscriber.UserName;
            var result = userManager.Create(user, subscriber.Password.password);
            //  result.Errors
            if (result.Succeeded)
            {
                return true;
            }
            else { return false; }
        }

        public static bool CreateEmployee(Subscriber user)
        {
            CreateUser(user);
            AddUserToRole(user.UserName, Roles.Subscriber);
            if (user.IsCompanyAdmin == true)
                AddUserToRole(user.UserName, Roles.CompanyAdmin);
            else
                AddUserToRole(user.UserName, Roles.CompanyEmployee);
            return true;
        }

        public static Subscriber GetSubscriber(string emailOrPhoneNumber)
        {
            var userRepository = new UserRepository(new RealEstateBrokerEntities());
            return userRepository.GetSubscriberByMailOrPhoneNumber(emailOrPhoneNumber);
        }
        public static ValidationResult CheckUserExist(Subscriber subscriber)
        {
            var validationResult = new ValidationResult { IsValid = true };
            var userRepository = new UserRepository(new RealEstateBrokerEntities());
            var user = userRepository.GetSubscriberByUsername(subscriber.UserName);
            //RegisterForDevelopment(subscriber, userRepository);
            if (user != null)
            {
                validationResult.IsValid = false;
                validationResult.Message = Messages.InValidUserName;
                return validationResult;
            }
            user = userRepository.GetSubscriberByMail(subscriber.Email);
            if (user != null)
            {
                validationResult.IsValid = false;
                validationResult.Message = Messages.InValidEmail;
                return validationResult;
            }
            user = userRepository.GetSubscriberByPhoneNumber(subscriber.MobileNo);
            if (user != null)
            {
                validationResult.IsValid = false;
                validationResult.Message = Messages.InValidMobileNo;
                return validationResult;
            }
            return validationResult;
        }
        private static void RegisterForDevelopment(Subscriber subscriber, UserRepository userRepository)
        {
            var user = (userRepository.GetSubscriberForLogin(subscriber.Email) ?? userRepository.GetSubscriberForLogin(subscriber.UserName)) ??
                       userRepository.GetSubscriberForLogin(subscriber.MobileNo);
            if (user == null)
                return;
            var userManager = new UserManager();
            var applicationUser = userManager.FindByName(user.UserName);
            if (string.Equals(user.UserName, "ahmadkhaled84@gmail.com", StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(user.UserName, "ahmad_4578@yahoo.com", StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(user.Email, "ahmadkhaled84@gmail.com", StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(user.Email, "ahmad_4578@yahoo.com", StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(user.MobileNo, "01143789352", StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(user.MobileNo, "01094434068", StringComparison.CurrentCultureIgnoreCase))
                userManager.Delete(applicationUser);
        }
        public static ValidationResult MatchPassword(Subscriber subscriber)
        {
            var validationResult = new ValidationResult();
            validationResult.IsValid = true;
            if (subscriber.Password.password.Length < 6)
            {
                validationResult.IsValid = false;
                validationResult.Message = Messages.ValidPassword;
            }
            if (subscriber.Password.password != subscriber.Password.ConfirmPassword)
            {
                validationResult.IsValid = false;
                validationResult.Message = Messages.PasswordNotMatch;
            }
            return validationResult;
        }
        public static void SignOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}