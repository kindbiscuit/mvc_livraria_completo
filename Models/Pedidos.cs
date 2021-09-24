using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Pedidos
        
    {
        
        [Display(Name = "Pedido Nº")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O pedido deve possuir no mínimo 1 item")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "O pedido deve ter um endereço de entrega")]
        [Display(Name = "Endereço de entrega")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "O pedido deve ter um título selecionado")]
        [Display(Name = "Livro")]
        public int? livroId { get; set; }
        public Livros livro { get; set; }

    }
}
