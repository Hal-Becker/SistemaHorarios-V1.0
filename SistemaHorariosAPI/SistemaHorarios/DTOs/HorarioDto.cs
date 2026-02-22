namespace SistemaHorarios.API.DTOs
{
    public class HorarioDto
    {
        public int IdHorario { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public DocenteDto Docente { get; set; }
        public AsignaturaDto Asignatura { get; set; }
        public AulaDto Aula { get; set; }
        public GrupoDto Grupo { get; set; }
    }
}