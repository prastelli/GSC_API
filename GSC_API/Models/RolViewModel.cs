using GSC_API.Entities;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using System.ComponentModel.DataAnnotations;

namespace GSC_API.Models
{
    public class RolViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "RolDescription es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El nombre solo puede tener 20 caracteres.")]
        public string RolDescription { get; set; }
    }
}
