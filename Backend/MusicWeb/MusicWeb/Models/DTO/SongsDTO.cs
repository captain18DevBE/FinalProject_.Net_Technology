using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MusicWeb.Models.Domain;

namespace MusicWeb.Models.DTO
{
    public class SongsDTO
    {
        public Songs Songs { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
