using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MantenimientoAPI.Models;  // Asegura que se importa el espacio de nombres correcto

namespace MantenimientoAPI.Models
{
    public class Mantenimiento
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")]
        public int Tecnico_ID { get; set; }

        [ForeignKey("Maquinaria")]
        public int Maquinaria_ID { get; set; }

        public string Estado { get; set; }

        public Usuario Tecnico { get; set; }  // Relación con Usuarios
        public Maquinaria Maquinaria { get; set; }  // Relación con Maquinaria
    }
}
