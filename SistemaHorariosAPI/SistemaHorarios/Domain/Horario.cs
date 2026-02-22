using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaHorarios.Domain
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }

        public int IdDocente { get; set; }
        public int IdAsignatura { get; set; }
        public int IdAula { get; set; }
        public int IdGrupo { get; set; }

        public string DiaSemana { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        [ForeignKey(nameof(IdDocente))]
        public Docente? Docente { get; set; }

        [ForeignKey(nameof(IdAsignatura))]
        public Asignatura? Asignatura { get; set; }

        [ForeignKey(nameof(IdAula))]
        public Aula? Aula { get; set; }

        [ForeignKey(nameof(IdGrupo))]
        public Grupo? Grupo { get; set; }
    }
}