using MusicWeb.Models.Domain;

namespace MusicWeb.Repositories.Abstract
{
    public interface ISongsService
    {
        Task<Songs> GetSongsById(int songId);
    }
}
