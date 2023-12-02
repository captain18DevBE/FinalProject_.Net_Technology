using System.ComponentModel.DataAnnotations;

namespace MusicWeb.Models.Domain
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }

    }
}
