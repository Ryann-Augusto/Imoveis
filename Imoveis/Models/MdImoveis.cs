using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table("imovel")]
    public class MdImoveis
    {
        [Key]
        [Display(Name = "id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("descricao", TypeName = "varchar(100)")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("valor" ,TypeName= "decimal(18,2)")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("quartos")]
        [Display(Name = "Número de quartos")]
        public int Quarto { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("vagas")]
        [Display(Name = "Número de vagas")]
        public int Vagas { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("tipo", TypeName = "varchar(15)")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("endereco", TypeName = "varchar(100)")]
        [Display(Name = "Endereço")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("bairro", TypeName = "varchar(30)")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        [Column("cidade", TypeName = "varchar(30)")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("estado", TypeName = "varchar(30)")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("cep", TypeName = "varchar(8)")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Column("usuarioid")]
        [Display(Name = "Anunciante")]
        public int UsuarioId { get; set; }
        public MdUsuarios Usuario { get; set; }

    }
}
