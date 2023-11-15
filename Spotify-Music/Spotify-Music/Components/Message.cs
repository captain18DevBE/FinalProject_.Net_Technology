using Microsoft.AspNetCore.Mvc;

namespace Spotify_Music.Components
{
    public class Message : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
