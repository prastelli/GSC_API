using GSC_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace GSC_API.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName es obligatorio.")]
        [MaxLength(20, ErrorMessage = "UserName debe tener 6 caracteres como Mínimo.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Password debe tener 6 caracteres como Mínimo.")]
        public string Password { get; set; }
        public Rol? Rol { get; set; }
        public int RolId { get; set; }
    }
}
