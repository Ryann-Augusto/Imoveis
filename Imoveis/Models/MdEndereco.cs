using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Owned]
    public class MdEndereco
    {
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("endereco", TypeName = "varchar(100)")]
        [Display(Name = "Endereço")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("numero", TypeName = "varchar(15)")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(45, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("complemento", TypeName = "varchar(45)")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(45, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("referencia", TypeName = "varchar(45)")]
        [Display(Name = "Ponto de Referencia")]
        public string Referencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("bairro", TypeName = "varchar(45)")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(45, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("cidade", TypeName = "varchar(45)")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres.")]
        [Column("estado", TypeName = "varchar(2)")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("cep", TypeName = "varchar(8)")]
        [RegularExpression(@"[0-9]{8}$", ErrorMessage = "O campo \"{0}\" deve ser com um CEP válido.")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }
    }
}
