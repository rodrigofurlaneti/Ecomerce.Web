using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Domain.Model
{
    [Table("Legal")]
    public class Legal : Base
    {
        [Key]
        public int LegalId { get; set; }
        [Required(ErrorMessage = "O CNPJ da empresa deve ser informado")]
        [Display(Name = "Número do CNPJ")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? NationalRegisterOfLegal { get; set; }

        [Required(ErrorMessage = "O nome da razão social da empresa deve ser informado")]
        [Display(Name = "Nome da razão social")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? CorporateReason { get; set; }

        [Required(ErrorMessage = "O nome fantasia da empresa deve ser informado")]
        [Display(Name = "Nome fantasia")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? FantasyName { get; set; }

        [Required(ErrorMessage = "A situação da empresa deve ser informado")]
        [Display(Name = "Situação")]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Situation { get; set; }

        [Required(ErrorMessage = "O(s) sócio(s) da empresa deve ser informado")]
        [Display(Name = "O(s) sócio(s)")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Members { get; set; }

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
