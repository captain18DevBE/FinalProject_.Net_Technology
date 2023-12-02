using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;
using MusicWeb.Models.DTO;

namespace MusicWeb.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContext _context;

        public AdminController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Display()
        {
            return View();
        }

        public async Task<IActionResult> ListUser()
        {
            List<User> resultList = new List<User>();
            var users = await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                User member = new User();
                member.FullName = user.Name;
                member.FullName = user.UserName;
                member.Email = user.Email;
                member.Phone = user.PhoneNumber;
                member.Password = user.PasswordHash;
                resultList.Add(member);
            }
            return View(resultList);
        }
    }
}
