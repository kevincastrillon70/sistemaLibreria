using System.ComponentModel.DataAnnotations;

namespace TallerSiriWeb.Models
{
    public class LibroModel
    {
        [Required]
        public int id{ get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string? titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string? autor { get; set; }
        [Required(ErrorMessage = "El genero es obligatorio")]
        public string? genero { get; set; }
        [Required(ErrorMessage = "fecha publicacion es obligatorio")]
        public string? fechapublicacion { get; set; }
    }
}
