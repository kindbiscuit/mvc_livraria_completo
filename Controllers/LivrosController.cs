using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Livraria.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Livraria.Controllers
{
    public class LivrosController : Controller
    {
        ILivrosService _service, _serviceSql, _serviceStatic, _serviceTudo;
        
       

        public LivrosController(LivrosSqlService serviceSql, LivrariaStaticService serviceStatic, LivrosFullService serviceTudo) 
        {

            this._serviceSql = serviceSql;
            this._serviceStatic = serviceStatic;
            this._serviceTudo = serviceTudo;
            _service = serviceSql;

        }

        public void SelectService(string service="sql") 
        {
            switch (service)
            {
                case "static":
                    this._service = this._serviceStatic;
                    break;
                case "both":
                    this._service = this._serviceTudo;
                    break;
                default:
                    this._service = this._serviceSql;
                    break;
            }
        }


        public  IActionResult Index(IdentityUser user, string busca, bool ordenar = false, string service = "sql")
        {
            SelectService(service);
            ViewBag.ordenar = ordenar;
            ViewBag.total = _service.getAll().Count();
            ViewBag.service = service;
            ViewBag.nome = user.NormalizedUserName;

            return base.View(this._service.getAll(busca, ordenar));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize]
        public IActionResult Create(Livros livro)
        {
            if (!ModelState.IsValid) return View(livro);
            return _service.create(livro) ?
                RedirectToAction(nameof(Index)) : View(livro);
        }

        public IActionResult Read(int? id)
        {
            Livros livros = _service.get(id);
            return livros != null ?
                View(livros) :
                NotFound();
        }

        [Authorize]
        public IActionResult Update(int? id)
        {
            Livros livros = _service.get(id);
            return livros != null ?
                View(livros) :
                NotFound();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Livros livros)
        {
            if (!ModelState.IsValid) return View(livros);
            if (_service.update(livros))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(livros);
            }
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (_service.delete(id)) 
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
