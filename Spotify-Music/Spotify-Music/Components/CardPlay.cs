using Microsoft.AspNetCore.Mvc;

namespace Spotify_Music.Components
{
    public class CardPlay : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
