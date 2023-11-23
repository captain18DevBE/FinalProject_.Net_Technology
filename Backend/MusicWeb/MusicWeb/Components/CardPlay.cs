using Microsoft.AspNetCore.Mvc;
using MusicWeb.Models.Domain;

namespace MusicWeb.Components
{
    public class CardPlay : ViewComponent
    {
        private readonly DatabaseContext _context;

        public CardPlay(DatabaseContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke() { 
            return View(_context.Songs.ToList()); 
        }
    }
}
