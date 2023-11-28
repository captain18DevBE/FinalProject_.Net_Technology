using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;
using MusicWeb.Repositories.Abstract;

namespace MusicWeb.Repositories.Implementation
{
    public class SongsService : ISongsService
    {
        private readonly DatabaseContext _databaseContext;

        public SongsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Songs> GetSongsById(int songId)
        {

            var songData = await _databaseContext.Songs
                .Where(m => m.SongId == songId)
                .FirstOrDefaultAsync();
            return songData;
        }
    }
}
