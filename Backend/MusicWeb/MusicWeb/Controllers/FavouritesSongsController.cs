using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;
using MusicWeb.Models.DTO;
using MusicWeb.Repositories.Implementation;

namespace MusicWeb.Controllers
{
    public class FavouritesSongsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly FavouriteSongsService _favouriteSongsService;
        public FavouritesSongsController(DatabaseContext context, FavouriteSongsService favouriteSongsService)
        {
            _context = context;
            _favouriteSongsService = favouriteSongsService;
        }

        // GET: FavouritesSongs
        public async Task<IActionResult> Index()
        {
            string username = HttpContext.Request.Query["username"];
            FavouriteSongsModel favouriteSongsModel = new FavouriteSongsModel();
            favouriteSongsModel.UserName = username;
            favouriteSongsModel.songs = new List<Songs>();
            var listFavourites = await _context.FavouritesSongs.ToListAsync();
            foreach (var item in listFavourites)
            {
                if(username == item.UserName)
                {
                    var song = await _context.Songs.FindAsync(item.SongId);
                    favouriteSongsModel.songs.Add(song);
                }
            }

            return View(favouriteSongsModel);
        }

        // GET: FavouritesSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FavouritesSongs == null)
            {
                return NotFound();
            }

            var favouritesSongs = await _context.FavouritesSongs
                .FirstOrDefaultAsync(m => m.FavoritesId == id);
            if (favouritesSongs == null)
            {
                return NotFound();
            }

            return View(favouritesSongs);
        }

        // GET: FavouritesSongs/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateNew(int id)
        {
            FavouritesSongs save = new FavouritesSongs();
            FavouritesSongs lastInstance = await _favouriteSongsService.GetLastInstanceAnsyc();
            var userName = HttpContext.Request.Query["username"];

            save.SongId = id;
            save.UserName = userName;
            if (ModelState.IsValid)
            {
                _context.Add(save);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NoContent();
        }

        // POST: FavouritesSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,UserName")] FavouritesSongs favouritesSongs)
        {
            FavouritesSongs lastInstance = await _favouriteSongsService.GetLastInstanceAnsyc();
            favouritesSongs.FavoritesId = lastInstance.FavoritesId + 1;
            if (ModelState.IsValid)
            {
                _context.Add(favouritesSongs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favouritesSongs);
        }

        // GET: FavouritesSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FavouritesSongs == null)
            {
                return NotFound();
            }

            var favouritesSongs = await _context.FavouritesSongs.FindAsync(id);
            if (favouritesSongs == null)
            {
                return NotFound();
            }
            return View(favouritesSongs);
        }


        // POST: FavouritesSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoritesId,SongId,UserName")] FavouritesSongs favouritesSongs)
        {
            if (id != favouritesSongs.FavoritesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favouritesSongs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouritesSongsExists(favouritesSongs.FavoritesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(favouritesSongs);
        }

        // GET: FavouritesSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FavouritesSongs == null)
            {
                return NotFound();
            }

            var favouritesSongs = await _context.FavouritesSongs
                .FirstOrDefaultAsync(m => m.FavoritesId == id);
            if (favouritesSongs == null)
            {
                return NotFound();
            }

            return View(favouritesSongs);
        }

        // POST: FavouritesSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FavouritesSongs == null)
            {
                return Problem("Entity set 'DatabaseContext.FavouritesSongs'  is null.");
            }
            var favouritesSongs = await _context.FavouritesSongs.FindAsync(id);
            if (favouritesSongs != null)
            {
                _context.FavouritesSongs.Remove(favouritesSongs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouritesSongsExists(int id)
        {
          return (_context.FavouritesSongs?.Any(e => e.FavoritesId == id)).GetValueOrDefault();
        }
    }
}
