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
        [Display(Name = "Descrição do imovel")]
        public string ImovelDsc{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelvlr" ,TypeName= "decimal(18,2)")]
        public decimal ImovelVlr{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelnumQrt")]
        public int ImovelNumQrt { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelnumvag")]
        public int ImovelNumVag { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imoveltip", TypeName = "varchar(15)")]
        public string ImovelTip { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelrua", TypeName = "varchar(100)")]
        public string ImovelRua { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelbro", TypeName = "varchar(30)")]
        public string ImovelBro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        [Column("imovelcdd", TypeName = "varchar(30)")]
        public string ImovelCdd { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imoveluf", TypeName = "varchar(30)")]
        public string ImovelUF { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("imovelcep", TypeName = "varchar(8)")]
        public string ImovelCEP { get; set; }

        [Column("usuarioid")]
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }

    }
}
