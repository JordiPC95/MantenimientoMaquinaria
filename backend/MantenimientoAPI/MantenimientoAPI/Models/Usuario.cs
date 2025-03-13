using System.ComponentModel.DataAnnotations;

namespace MantenimientoAPI.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [Required]
        public string Rol { get; set; }
    }
}
