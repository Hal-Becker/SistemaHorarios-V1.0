using System.ComponentModel.DataAnnotations;

namespace SistemaHorarios.Domain
{
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }

        public string Nombre { get; set; }

        public string NivelEducativo { get; set; }

        public ICollection<Horario>? Horarios { get; set; }
    }
}