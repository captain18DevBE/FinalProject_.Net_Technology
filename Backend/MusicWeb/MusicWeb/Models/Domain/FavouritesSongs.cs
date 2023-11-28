using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicWeb.Models.Domain
{
    public class FavouritesSongs
    {
        [Key]
        public int FavoritesId { get; set; }
        [ForeignKey("Songs")]
        public int SongId { get; set; }
        [Required]
        public string? UserName { get; set; }
    }
}
