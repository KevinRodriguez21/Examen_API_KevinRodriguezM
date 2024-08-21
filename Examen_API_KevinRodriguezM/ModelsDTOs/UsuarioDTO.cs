using Examen_API_KevinRodriguezM.Models;

namespace Examen_API_KevinRodriguezM.ModelsDTOs
{
    public class UsuarioDTO
    {

        public int UserId { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Telefono { get; set; }

        public string Contrasennia { get; set; } = null!;

        public int StrikeConteo { get; set; }

        public string CorreoRespaldo { get; set; } = null!;

        public string? DescripcionTrabajo { get; set; }

        public int IdEstatusUsuario { get; set; }

        public int IdPais { get; set; }

        public int IdRolUsuario { get; set; }


        public string? Pais { get; set; }



        public string? RolUsuario { get; set; }

        public string? EstatusUsuario { get; set; }

    }
}
