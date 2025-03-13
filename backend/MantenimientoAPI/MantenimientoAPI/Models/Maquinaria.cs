using System.ComponentModel.DataAnnotations;

namespace MantenimientoAPI.Models
{
    public class Maquinaria
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Nombre { get; set; }

        public required string Modelo { get; set; }
        public required string Ubicacion { get; set; }
        public required string Estado { get; set; }
    }
}
