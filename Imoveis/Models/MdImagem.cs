using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imoveis.Models
{
    [Table("imagens")]
    public class MdImagens
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao", TypeName = "varchar(100)")]
        public string Descricao { get; set; }
        [Column("dados")]
        public byte[] Dados { get; set; }
        [Column("type", TypeName = "varchar(60)")]
        public string ContentType { get; set; }

        [Column("imovelid")]
        [Display(Name = "Imovel")]
        public int ImovelId { get; set; }
        public MdImoveis? Imovel { get; set; }
    }
}
