using Examen_API_KevinRodriguezM.Models;

namespace Examen_API_KevinRodriguezM.ModelsDTOs
{
    public class PreguntaDTO
    {
        public long IdPregunta { get; set; }

        public DateTime Fecha { get; set; }

        public string Pregunta1 { get; set; } = null!;

        public int IdUsuario { get; set; }

        public int IdPreguntaEstado { get; set; }

        public bool? EsStrike { get; set; }

        public string? DireccionImagen { get; set; }

        public string? DetallePregunta { get; set; }


        public string EstadoPregunta { get; set; } = null!;

        public string Usuario { get; set; } = null!;

    }
}
