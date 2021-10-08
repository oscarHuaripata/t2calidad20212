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
    public class HomeControllerTest
    {
        [Test]

        public void DebePoderRetornarUnaListaDeLibros()
        {
            var lista = new Mock<ILibros>();

            lista.Setup(o => o.GetLibros()).Returns(new List<Libro>());

            var controller = new HomeController(lista.Object);



            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Libro>>(view.Model);
        }
        [Test]

        public void NoDebePoderRetornarUnaListaDeLibros()
        {
            var lista = new Mock<ILibros>();

            lista.Setup(o => o.GetLibros());

            var controller = new HomeController(lista.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsNull(view.Model);
        }
    }
}
