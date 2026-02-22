using System.Text.Json.Serialization;

namespace SistemaHorarios.Web.Models
{
    public class HorarioDto
    {
        [JsonPropertyName("idHorario")]
        public int IdHorario { get; set; }

        [JsonPropertyName("diaSemana")]
        public string DiaSemana { get; set; }

        [JsonPropertyName("horaInicio")]
        public string HoraInicio { get; set; }

        [JsonPropertyName("horaFin")]
        public string HoraFin { get; set; }

        [JsonPropertyName("docente")]
        public DocenteDto? Docente { get; set; }

        [JsonPropertyName("asignatura")]
        public AsignaturaDto? Asignatura { get; set; }

        [JsonPropertyName("aula")]
        public AulaDto? Aula { get; set; }

        [JsonPropertyName("grupo")]
        public GrupoDto? Grupo { get; set; }
    }

    public class DocenteDto
    {
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }
    }

    public class AsignaturaDto
    {
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }
    }

    public class AulaDto
    {
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }
    }

    public class GrupoDto
    {
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }
    }
}