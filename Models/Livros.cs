using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Livros
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome do livro!")]
        [Display(Name = "Título")]
        public string Nome { get; set; }

        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Informe o nome do autor!")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Display(Name ="Edição")]
        public string Edicao { get; set; }

        [Display(Name ="Lançamento")]
        public int Lancamento { get; set; }
    }
}
