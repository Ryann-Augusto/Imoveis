using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table("imovel")]
    public class Imovel
    {
        [Key]
        [Display(Name = "Id")]
        public int ImovelId { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imoveldsc", TypeName = "varchar(100)")]
        [Display(Name = "Descrição")]
        public string ImovelDsc{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelvlr" ,TypeName= "decimal(18,2)")]
        [Display(Name = "Valor")]
        public decimal ImovelVlr{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelnumQrt")]
        [Display(Name = "Número de quartos")]
        public int ImovelNumQrt { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelnumvag")]
        [Display(Name = "Número de vagas")]
        public int ImovelNumVag { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imoveltip", TypeName = "varchar(15)")]
        [Display(Name = "Tipo")]
        public string ImovelTip { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelrua", TypeName = "varchar(100)")]
        [Display(Name = "Endereço")]
        public string ImovelRua { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelbro", TypeName = "varchar(30)")]
        [Display(Name = "Bairro")]
        public string ImovelBro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        [Column("imovelcdd", TypeName = "varchar(30)")]
        [Display(Name = "Cidade")]
        public string ImovelCdd { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imoveluf", TypeName = "varchar(30)")]
        [Display(Name = "Estado")]
        public string ImovelUF { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelcep", TypeName = "varchar(8)")]
        [Display(Name = "CEP")]
        public string ImovelCEP { get; set; }

        [Column("usuarioid")]
        [Display(Name = "Anunciante")]
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }

    }
}
