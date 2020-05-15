using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtual.Models
{
    [MetadataType(typeof(GeneroMetaData))]
    public partial class Genero
    {
    }

    public class GeneroMetaData
    {
        [ScaffoldColumn(false)]
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MinLength(5, ErrorMessage = "{0} debe tener más de 4 caracteres")]
        [MaxLength(100, ErrorMessage = "{0} debe tener máximo 100 caracteres")]
        [Display(Name = "Género Literario")]
        public string Nombre { get; set; }
    }
}
