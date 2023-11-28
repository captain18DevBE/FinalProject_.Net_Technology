using MusicWeb.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MusicWeb.Models.DTO
{
    public class FavouriteSongsModel
    {
        [Required]
        public List<Songs> songs { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
