using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Services
{
    public class LivrosFullService : ILivrosService
    {
        ILivrosService _serviceStatic, _serviceSql;
        public LivrosFullService(LivrariaStaticService serviceStatic, LivrosSqlService serviceSql) 
        {
            _serviceStatic = serviceStatic;
            _serviceSql = serviceSql;
        }

        public List<Livros> getAll(string busca = null, bool ord = false)
        {
            List<Livros> livrosSql = _serviceSql.getAll(busca, ord);
            List<Livros> livrosStatic = _serviceStatic.getAll(busca, ord);

            List<Livros> lista = livrosStatic.Concat(livrosSql).ToList();

            if (busca != null)
            {
                return lista.FindAll(a =>
                    a.Nome.ToLower().Contains(busca.ToLower())
                );
            }

            if (ord)
            {
                lista = lista.OrderBy(l => l.Nome).ToList();
                return lista;
            }
            return lista;
        }
        public bool create(Livros livros)
        {
            return false;
        }

        public bool delete(int? id)
        {
            return false;
        }

        public Livros get(int? id)
        {
            return new();
        }

       

        public bool update(Livros l)
        {
            return false;
        }
    }
}
