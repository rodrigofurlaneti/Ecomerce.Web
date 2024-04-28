using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Web.Model
{
    [Table("Register")]
    public class Register
    {
        [Key]
        public int RegisterId { get; set; }

        [Required(ErrorMessage = "O telefone deve ser informado")]
        [Display(Name = "Telefone")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado")]
        [Display(Name = "CEP")]
        [StringLength(8, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? ZipCode { get; set; }

        [Required(ErrorMessage = "O endereço deve ser informado")]
        [Display(Name = "Endereço")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "O número deve ser informado")]
        [Display(Name = "Número")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Number { get; set; }

        [Required(ErrorMessage = "O bairro deve ser informado")]
        [Display(Name = "Bairro")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Neighborhood { get; set; }

        [Required(ErrorMessage = "A cidade deve ser informado")]
        [Display(Name = "Cidade")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? City { get; set; }

        [Required(ErrorMessage = "O estado deve ser informado")]
        [Display(Name = "Estado")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? State { get; set; }

        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [Display(Name = "E-mail")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha deve ser informado")]
        [Display(Name = "Senha")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Password { get; set; }

        [Display(Name = "Confirmou o e-mail?")]
        public bool? ConfirmedEmail { get; set; }
    }
}
