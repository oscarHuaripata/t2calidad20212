﻿using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interface;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    public class LibroController : Controller
    {
        private ILibros ilibros;
        private IAddComentario addComentario;
        private IUsuario usuarioSession;
        public LibroController(ILibros ilibros, IAddComentario addComentario, IUsuario usuarioSession)
        {
            this.ilibros = ilibros;
            this.addComentario = addComentario;
            this.usuarioSession = usuarioSession;
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = ilibros.GetLibroId(id);
            return View(model); 
        }
        [HttpPost]
        public ActionResult AddComentario(Comentario comentario)
        {
            

            Usuario user = usuarioSession.setNombreUsuario();

            addComentario.AddComentario(comentario, user);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }
        private Usuario GetUsuario()
        {
            return (Usuario)Session["Usuario"];
        }
    }
}