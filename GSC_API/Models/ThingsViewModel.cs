using GSC_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace GSC_API.Models
{
    public class ThingsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El nombre solo puede tener 20 caracteres.")]
        public string Description { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
