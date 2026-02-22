using System.ComponentModel.DataAnnotations;

namespace SistemaHorarios.Domain
{
    public class Aula
    {
        [Key]
        public int IdAula { get; set; }

        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        public ICollection<Horario>? Horarios { get; set; }
    }
}