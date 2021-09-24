using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Services
{
    public interface ILivrosService
    {
        bool create(Livros livros);
        bool delete(int? id);
        Livros get(int? id);
        List<Livros> getAll(string busca = null, bool ord = false);
        bool update(Livros l);
    }
}
