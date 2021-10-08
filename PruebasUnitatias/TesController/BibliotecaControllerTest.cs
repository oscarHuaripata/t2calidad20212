using BibliotecaUPN.Web.Controllers;
using BibliotecaUPN.Web.Interface;
using BibliotecaUPN.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebasUnitatias.TesController
{
    [TestFixture]
    public class BibliotecaControllerTest
    {
        [Test]
        public void ListaDeBibliotecas()
        {
            var sess = new Mock<IUsuario>();
            var list = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.Index() as ViewResult;

            Assert.IsInstanceOf<List<Biblioteca>>(view.Model);
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AddBiblioteca()
        {
            var sess = new Mock<IUsuario>();
            var list = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void MarcarComoLeyendo()
        {
            var sess = new Mock<IUsuario>();
            var list = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.MarcarComoLeyendo(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void MarcarComoTerminado()
        {
            var sess = new Mock<IUsuario>();
            var list = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "oscar",
                Password = "Admin",
                Username = "Admin"
            };

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, sess.Object);

            var view = listaBi.MarcarComoTerminado(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }

    }

}
