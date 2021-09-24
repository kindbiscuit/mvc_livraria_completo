using System;
using System.Collections.Generic;
using System.Linq;
using Livraria.Data;
using System.Threading.Tasks;
using Livraria.Models;

namespace Livraria.Services
{
    public class LivrosSqlService:ILivrosService
    {
        LivrariaContext context;
        public LivrosSqlService(LivrariaContext context)
        {
            this.context = context;
        }

        public List<Livros> getAll(string busca = null, bool ord = false)
        {
            List<Livros> lista = context.livros.ToList();
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

            try
            {
                context.livros.Add(livros);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Livros get(int? id)
        {
            return context.livros.Find(id);
        }

        public bool update(Livros l)
        {
            try
            {
                context.livros.Update(l);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int? id)
        {
            try
            {
                context.livros.Remove(get(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
