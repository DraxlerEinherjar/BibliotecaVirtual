using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtual.Models
{
    [MetadataType(typeof(AutorMetaData))]
    public partial class Autor
    {
    }

    public class AutorMetaData
    {
        [ScaffoldColumn(false)]
        public object IdAutor { get; set; }
        [Required(ErrorMessage ="{0} es requerido")]
        [MinLength(5,ErrorMessage = "{0} debe tener más de 4 caracteres")]
        [MaxLength(100,ErrorMessage = "{0} debe tener máximo 100 caracteres")]
        [Display(Name= "Nombre de Autor")]
        public object Nombre { get; set; }
    }
}