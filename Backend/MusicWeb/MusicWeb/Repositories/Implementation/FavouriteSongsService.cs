using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;
using MusicWeb.Repositories.Abstract;

namespace MusicWeb.Repositories.Implementation
{
    public class FavouriteSongsService : IFavouriteSongsService
    {
        private readonly DatabaseContext _databaseContext;
        public FavouriteSongsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<FavouritesSongs> GetLastInstanceAnsyc()
        {
            var lastFavouriteSong = await _databaseContext.FavouritesSongs
                .OrderByDescending(s => s.SongId) 
                .FirstOrDefaultAsync();

            return lastFavouriteSong;
        }
    }
}
