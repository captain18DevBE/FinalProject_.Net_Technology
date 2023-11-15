using Microsoft.AspNetCore.Mvc;

namespace Spotify_Music.Components
{
    public class Navbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
