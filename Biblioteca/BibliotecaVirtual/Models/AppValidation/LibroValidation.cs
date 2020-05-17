using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtual.Models
{
    [MetadataType(typeof(LibroMetaData))]
    public partial class Libro
    {
    }

    public class LibroMetaData
    {
        [ScaffoldColumn(false)]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [MinLength(2, ErrorMessage = "{0} debe tener mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "{0} debe tener máximo 100 caracteres")]
        [Display(Name = "Título")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1,Int32.MaxValue, ErrorMessage = "El valor para {0} no es válido")]
        [Display(Name = "Autor")]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor para {0} no es válido")]
        [Display(Name = "Editorial")]
        public int IdEditorial { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de publicación")]
        public System.DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor para {0} no es válido")]
        [Display(Name = "Estado")]
        public int IdEstadoLibro { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor para {0} no es válido")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(0, 9999999999999999.99, ErrorMessage = "El valor para {0} no es válido")]
        [Display(Name = "Precio Unitario")]
        public double PrecioUnitario { get; set; }

        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El valor para {0} no es válido")]
        [Display(Name = "Género")]
        public int IdGenero { get; set; }
    }
}