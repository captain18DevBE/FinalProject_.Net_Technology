using Microsoft.AspNetCore.Mvc;

namespace MusicWeb.Components
{
    public class Search : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
