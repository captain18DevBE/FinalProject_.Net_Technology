using Microsoft.AspNetCore.Mvc;

namespace Spotify_Music.Components
{
    public class Notification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
