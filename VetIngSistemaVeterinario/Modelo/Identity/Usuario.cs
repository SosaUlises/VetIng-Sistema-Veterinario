using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VetIngSistemaVeterinario.Modelo.Identity
{
    public class Usuario : IdentityUser<int>
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
