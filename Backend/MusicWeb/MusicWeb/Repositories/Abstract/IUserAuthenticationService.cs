using MusicWeb.Models.DTO;

namespace MusicWeb.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
        Task<Status> ChangePasswordAsync(ChangePasswordModel model);
    }
}
