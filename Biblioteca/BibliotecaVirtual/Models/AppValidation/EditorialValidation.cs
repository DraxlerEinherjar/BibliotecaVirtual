using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaVirtual.Models
{
    [MetadataType(typeof(EditorialMetaData))]
    public partial class Editorial
    {
    }

    public class EditorialMetaData
    {
        [ScaffoldColumn(false)]
        public object IdEditorial { get; set; }
        [Required(ErrorMessage ="{0} es requerido")]
        [MinLength(5,ErrorMessage ="{0} debe tener más de 4 caracteres")]
        [MaxLength(100, ErrorMessage = "{0} debe tener máximo 100 caracteres")]
        [Display(Name = "Nombre de Editorial")]
        public object Nombre { get; set; }
    }
}