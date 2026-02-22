namespace SistemaHorarios.Web.Models
{
    public class CreateHorarioViewModel
    {
        public int IdDocente { get; set; }
        public int IdAsignatura { get; set; }
        public int IdAula { get; set; }
        public int IdGrupo { get; set; }

        public string DiaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}