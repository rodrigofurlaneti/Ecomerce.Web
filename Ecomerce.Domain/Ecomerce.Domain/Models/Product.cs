using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O nome do produto deve ser informado")]
        [Display(Name = "Nome do Produto")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A descrição do produto deve ser informada")]
        [Display(Name = "Descrição do Produto")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "O descrição detalhada do produto deve ser informada")]
        [Display(Name = "Descrição detalhada do Produto")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string? DetailedDescription { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Price { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? ImageThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsPreferred { get; set; }

        [Display(Name = "Estoque")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
