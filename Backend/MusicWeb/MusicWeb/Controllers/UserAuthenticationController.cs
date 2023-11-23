using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicWeb.Models.DTO;
using MusicWeb.Repositories.Abstract;

namespace MusicWeb.Controllers
{
    public class UserAuthentication : Controller
    {
        private readonly IUserAuthenticationService _service;
        public UserAuthentication(IUserAuthenticationService service)
        {
            this._service = service;
        }

        //Action Registration
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await _service.RegistrationAsync(model);
            TempData["msg"] = result.StatusMessage;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.StatusMessage;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel
        //    {
        //        UserName = "user",
        //        Name = "Le Duy",
        //        Email = "tlduyuser18dev@gmail.com",
        //        Password = "Tranleduy@1808",
        //    };
        //    model.Role = "user";
        //    var result = await _service.RegistrationAsync(model);
        //    return Ok(result);
        //}
    }
}
