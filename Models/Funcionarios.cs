using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class Funcionarios
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome do funcionário!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Salário")]
        public double Salario { get; set; }

        [Required(ErrorMessage = "Informe a data de admissão!")]
        [Display(Name = "Data de admissão")]
        [DataType(DataType.Date)]
        public DateTime? Admissao { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Data de Nascimento")]
        public DateTime? Nascimento { get; set; }

        
        
    }
}
