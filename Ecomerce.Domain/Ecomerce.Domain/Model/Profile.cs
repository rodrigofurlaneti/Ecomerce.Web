using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Domain.Model
{
    public class Profile : Base
    {
        [Key]
        public int ProfileId { get; set; }

        [Required(ErrorMessage = "O nome do perfil deve ser informado")]
        [Display(Name = "Nome do perfil")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Name { get; set; }
    }
}
