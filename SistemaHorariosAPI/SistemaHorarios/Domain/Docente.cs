using System.ComponentModel.DataAnnotations;

namespace SistemaHorarios.Domain
{
    public class Docente
    {
        [Key]
        public int IdDocente { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Especialidad { get; set; }

        public int HorasMaximas { get; set; }

        public ICollection<Horario>? Horarios { get; set; }
    }
}