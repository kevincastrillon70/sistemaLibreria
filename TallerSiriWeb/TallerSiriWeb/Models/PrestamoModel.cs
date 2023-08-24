using System.ComponentModel.DataAnnotations;

namespace TallerSiriWeb.Models
{
    public class PrestamoModel
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "El libro es obligatorio")]
        public int? idlibro { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int? iduser { get; set; }
        [Required(ErrorMessage = "La fehca inicio es obligatoria")]
        public string? fechainicio { get; set; }
        [Required(ErrorMessage = "La fecha fin es obligatoria")]
        public string? fechafin { get; set; }
    }
}
