using System.ComponentModel.DataAnnotations;

namespace MantenimientoAPI.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Nombre { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Contraseña { get; set; }

        [Required]
        public required string Rol { get; set; }
    }
}
