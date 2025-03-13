using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MantenimientoAPI.Models
{
    public class Mantenimiento
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string Tipo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")]
        public int Tecnico_ID { get; set; }

        [ForeignKey("Maquinaria")]
        public int Maquinaria_ID { get; set; }

        public required string Estado { get; set; }

        public required Usuario Tecnico { get; set; }
        public required Maquinaria Maquinaria { get; set; }
    }
}
