using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;
using MusicWeb.Models.DTO;

namespace MusicWeb.Controllers
{
    public class SongsController : Controller
    {
        private readonly DatabaseContext _context;

        public SongsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Songs/Create
        public async Task<IActionResult> MusicPlay(int id)
        {
            int songId = id;
            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongId == songId);
            return View(songs);
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
              return _context.Songs != null ? 
                          View(await _context.Songs.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Songs'  is null.");
        }

        // Post: Seatch to Songs
        [HttpPost]
        public async Task<IActionResult> Search()
        {
            var searchName = Request.Form["searchName"].ToString();
            List<Songs> songs = await _context.Songs.ToListAsync();
            List<Songs> dataSearch = new List<Songs>();
            foreach (var item in songs)
            {
                if(item.SongName.Contains(searchName))
                {
                    dataSearch.Add(item);
                }
            }
            return View(dataSearch);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songs == null)
            {
                return NotFound();
            }
            return View(songs);
        }
        [Authorize(Roles = "admin")]
        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SongName,Rate,LinkLocal,LinkImg,Lyric")] Songs songs)
        {
            var linkLocal = songs.LinkLocal;
            songs.LinkLocal = "/data/audio/" + linkLocal+ ".mp3";
            songs.LinkImg = "/data/img/" + linkLocal+ ".jpg";
            if (ModelState.IsValid)
            {
                _context.Add(songs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songs);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,Title,SongName,Rate,LinkLocal,LinkImg,Lyric")] Songs songs)
        {
            if (id != songs.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongsExists(songs.SongId))
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
            return View(songs);
        }
        [Authorize(Roles = "admin")]
        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }
        [Authorize(Roles = "admin")]
        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Songs == null)
            {
                return Problem("Entity set 'DatabaseContext.Songs'  is null.");
            }
            var songs = await _context.Songs.FindAsync(id);
            if (songs != null)
            {
                _context.Songs.Remove(songs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongsExists(int id)
        {
          return (_context.Songs?.Any(e => e.SongId == id)).GetValueOrDefault();
        }
    }
}
