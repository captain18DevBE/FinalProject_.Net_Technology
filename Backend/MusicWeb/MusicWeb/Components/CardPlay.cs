using Microsoft.AspNetCore.Mvc;

namespace MusicWeb.Components
{
    public class CardPlay : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
