using Livraria.Models;
using System.Collections.Generic;

namespace Livraria.Services
{
    public interface IPedidosService
    {
        bool create(Pedidos pedidos);
        bool delete(int? id);
        Pedidos get(int? id);
        List<Pedidos> getAll();
        bool update (Pedidos p);
    }
}