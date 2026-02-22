namespace SistemaHorarios.Web.Models
{
    public class ScheduleViewModel
    {
        public int IdHorario { get; set; }
        public string Asignatura { get; set; }
        public string Docente { get; set; }
        public string Aula { get; set; }
        public string Grupo { get; set; }
        public string DiaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}