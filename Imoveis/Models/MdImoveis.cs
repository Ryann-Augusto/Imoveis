﻿using Microsoft.AspNetCore.Mvc;
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
        [Column("nome", TypeName = "varchar(100)")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("valor" ,TypeName= "decimal(18,2)")]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("quartos")]
        [Display(Name = "Número de Quartos")]
        public int Quarto { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("vagas")]
        [Display(Name = "Número de Vagas")]
        public int Vagas { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("banheiro")]
        [Display(Name = "Número de Banheiros")]
        public int Banheiro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("tipo", TypeName = "int")]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        [Column("situacao", TypeName = "int")]
        public int Situacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        [Column("descricao", TypeName = "text")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public MdEndereco Endereco { get; set; }

        public List<MdImagens>? Imagens { get; set; }

        [Column("usuarioid")]
        [Display(Name = "Anunciante")]
        public int UsuarioId { get; set; }
        public MdUsuarios? Usuario { get; set; }
    }
}
