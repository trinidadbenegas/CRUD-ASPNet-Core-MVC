using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Herramienta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TipoHerramienta { get; set; }
        [Required]
        public bool Disponibilidad { get; set; } = true;
        [Required]
        public string NombreReservante { get; set; }
        [Required]
        public string ApellidoReservante { get; set; }
        [Required]
        public int Dni { get; set; }
        [Required]
        public string Direccion { get; set; }



    }
}
