using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using E_PLAYERS.Models;

namespace E_PLAYERS.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiasModel = new Noticias();
        public IActionResult Index(){
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form){
            Noticias novaNoticia   = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo     = form["Titulo"];
            novaNoticia.Imagem   = form["Imagem"];

            noticiasModel.Create(novaNoticia);
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }
    }
}