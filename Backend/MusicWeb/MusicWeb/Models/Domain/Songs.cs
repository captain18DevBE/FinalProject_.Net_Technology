using System.ComponentModel.DataAnnotations;

namespace MusicWeb.Models.Domain
{
    public class Songs
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string SongName { get; set; }
        public int Rate { get; set; } = 0;

        public string LinkLocal { get; set; }

        public string LinkImg { get; set; }
        public string Lyric { get; set; }
    }
}
