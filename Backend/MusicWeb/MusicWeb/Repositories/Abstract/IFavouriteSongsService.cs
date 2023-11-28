using MusicWeb.Models.Domain;

namespace MusicWeb.Repositories.Abstract
{
    public interface IFavouriteSongsService
    {
        Task<FavouritesSongs> GetLastInstanceAnsyc();
    }
}
