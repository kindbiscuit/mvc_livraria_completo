using Livraria.Models;
using Livraria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    public class PedidosController : Controller
    {
        IPedidosService service;
        ILivrosService livrosService;

        public PedidosController(IPedidosService service, ILivrosService livrosService)
        {
            this.service = service;
            this.livrosService = livrosService;
        }

        public IActionResult Index()
        {

            ViewBag.totalPedidos = service.getAll().Count();
            return View(service.getAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var livros = livrosService.getAll();
            ViewBag.listaDeLivros = new SelectList(livros, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedidos pedidos)
        {
            var livros = livrosService.getAll();
            ViewBag.listaDeLivros = new SelectList(livros, "Id", "Nome");
            if (!ModelState.IsValid) return View(pedidos);

            if (service.create(pedidos))
                return RedirectToAction(nameof(Index));
            else
            {

                return View(pedidos);
            }
        }


        public IActionResult Read(int? id)
        {
            Pedidos pedidos = service.get(id);
            return pedidos != null ?
                View(pedidos) :
                NotFound();
        }

        public IActionResult Update(int? id)
        {
            var livros = livrosService.getAll();
            ViewBag.listaDeLivros = new SelectList(livros, "Id", "Nome");
            Pedidos pedidos = service.get(id);
            return pedidos != null ?
                View(pedidos) :
                NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Pedidos pedidos)
        {
            var livros = livrosService.getAll();
            ViewBag.listaDeLivros = new SelectList(livros, "Id", "Nome");
            
            if (!ModelState.IsValid) return View(livros);

            if (service.update(pedidos))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(pedidos);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (service.delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
