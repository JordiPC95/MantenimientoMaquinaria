using System.ComponentModel.DataAnnotations;

namespace MantenimientoAPI.Models
{
    public class Maquinaria
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Modelo { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }
    }
}
