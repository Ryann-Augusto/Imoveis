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
        [StringLength(200)]
        [Display(Name = "Descrição do imovel")]
        public string ImovelDsc{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column(TypeName= "decimal(18,2)")]
        public decimal ImovelVlr{ get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int ImovelNumQrt { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public int ImovelNumVag { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(15)]
        public string ImovelTip { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(100)]
        public string ImovelRua { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        public string ImovelBro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        public string ImovelCdd { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(30)]
        public string ImovelUF { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [StringLength(8)]
        public string ImovelCEP { get; set; }

        public List<Usuarios> Usuarios { get; set; }

    }
}
