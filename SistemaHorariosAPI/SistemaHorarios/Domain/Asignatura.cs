using System.ComponentModel.DataAnnotations;

namespace SistemaHorarios.Domain
{
    public class Asignatura
    {
        [Key]
        public int IdAsignatura { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int HorasSemanales { get; set; }

        public ICollection<Horario>? Horarios { get; set; }
    }
}