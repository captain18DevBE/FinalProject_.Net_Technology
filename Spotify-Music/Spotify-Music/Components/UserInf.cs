using Microsoft.AspNetCore.Mvc;

namespace Spotify_Music.Components
{
    public class UserInf : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
