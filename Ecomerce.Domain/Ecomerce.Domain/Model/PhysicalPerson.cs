using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Domain.Model
{
    [Table("PhysicalPerson")]
    public class PhysicalPerson : Base
    {
        [Key]
        public int PhysicalPersonId { get; set; }

        [Required(ErrorMessage = "O nome completo deve ser informado")]
        [Display(Name = "Nome completo")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "O gênero deve ser informado")]
        [Display(Name = "Gênero")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "A data de nascimento deve ser informado")]
        [Display(Name = "Data de nascimento")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? DateOfBirth { get; set; }

        [Required(ErrorMessage = "O CPF deve ser informado")]
        [Display(Name = "CPF")]
        [StringLength(150, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? RegistrationOfIndividuals { get; set; }

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
