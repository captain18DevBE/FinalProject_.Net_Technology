using Microsoft.AspNetCore.Mvc;

namespace MusicWeb.Components
{
    public class Navbar : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
