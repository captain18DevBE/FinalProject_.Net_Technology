using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Domain;
using MusicWeb.Models.DTO;
using MusicWeb.Repositories.Abstract;
using System.Security.Claims;
using System.Xml.Linq;

namespace MusicWeb.Repositories.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Status> LoginAsync(LoginModel model)
        {
            var status = new Status();
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "Sai ten dang nhap";
                return status;
            }

            //math password
            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.StatusMessage = "Mat khau khong dung";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                foreach (var userRole in userRoles) 
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                status.StatusCode = 1;
                status.StatusMessage = "Dang nhap tai khoan thanh cong";
                return status;
            } else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.StatusMessage = "Tai khoan da bi khoa";
                return status;
            } else
            {
                status.StatusCode = 0;
                status.StatusMessage = "Da co loi xay ra";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> RegistrationAsync(RegistrationModel model)
        {
            var status = new Status();
            var useExists = await userManager.FindByNameAsync(model.UserName);

            if (useExists != null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "Ton tai Nguoi dung";
                return status;
            }

            ApplicationUser user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.UserName,
                Email = model.Email,
                UserName = model.UserName,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.StatusMessage = "Tao nguoi dung that bai";
                return status;
            }

            //role manage
            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }

            status.StatusCode = 1;
            status.StatusMessage = "Tao tao khoan thanh cong";
            return status;
        }
    }
}
