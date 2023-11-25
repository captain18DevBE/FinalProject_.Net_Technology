using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;

namespace MusicWeb.Controllers
{
    public class SongsController : Controller
    {
        private readonly DatabaseContext _context;

        public SongsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
              return _context.Songs != null ? 
                          View(await _context.Songs.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Songs'  is null.");
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

        // GET: Songs/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,Title,SongName,Rate,LinkLocal,LinkImg,Lyric")] Songs songs)
        {
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,Title,SongName,Rate,LinkLocal,Lyric")] Songs songs)
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
