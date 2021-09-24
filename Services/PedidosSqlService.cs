using Livraria.Data;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Services
{
    public class PedidosSqlService : IPedidosService
    {
        LivrariaContext context;

        public PedidosSqlService(LivrariaContext context)
        {
            this.context = context;
        }

        public List<Pedidos> getAll()
        {
            return context.pedidos.Include(p => p.livro).ToList();
        }
        public bool create(Pedidos pedidos)
        {
            try
            {
                context.pedidos.Add(pedidos);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Pedidos get(int? id)
        {
            return context.pedidos.Include(p => p.livro).FirstOrDefault(p => p.Id == id);
        }

        public bool update(Pedidos p)
        {
            try
            {
                context.pedidos.Update(p);
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
                context.pedidos.Remove(get(id));
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
