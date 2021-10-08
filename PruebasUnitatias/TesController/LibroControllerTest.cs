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
using System.Web;
namespace PruebasUnitatias.TesController
{
    [TestFixture]
    public class LibroControllerTest
    {
        [Test]
        public void DebePoderRetonarUnDetalleId()
        {
            var retornarDetalle = new Mock<ILibros>();


            Libro libro = new Libro()
            {
                Nombre = "espero aprobar el curso :)",
                Id = 1,
                Autor = new Autor()
                {
                    Id = 1,
                    Nombres = "Libro1"
                },
                Comentarios = new List<Comentario>()
                {
                    new Comentario()
                    {
                        Id = 1,
                        Texto = "......"
                    }
                }
            };

            retornarDetalle.Setup(o => o.GetLibroId(1)).Returns(libro);

            var controller = new LibroController(retornarDetalle.Object, null, null);

            var resultado = controller.Details(1) as ViewResult;

            Assert.IsInstanceOf<Libro>(resultado.Model);
            Assert.IsInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void NoDebePoderRetonarUnDetalleId()
        {
            var retornarDetalle = new Mock<ILibros>();

            Libro libro = new Libro()
            {

                Nombre = "",
                Id = 1,
                Autor = new Autor()
                {
                    Id = 1,
                    Nombres = "Libro1"
                },
                Comentarios = new List<Comentario>()
                {
                    new Comentario()
                    {
                        Id = 1,
                        Texto = "................"
                    }
                }
            };

            retornarDetalle.Setup(o => o.GetLibroId(1)).Returns(libro);

            var controller = new LibroController(retornarDetalle.Object, null, null);

            var resultado = controller.Details(2) as ViewResult;

            Assert.IsNull(resultado.Model);
            Assert.IsInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void DebePoderAddComentario()
        {
            var agregarComentario = new Mock<IAddComentario>();

            var sess = new Mock<IUsuario>();

            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "oscar",
                Password = "Admin",
                Username = "Admin"
            };

            Comentario comentario = new Comentario()
            {

                Texto = "Espero Aprobar el curso :)",
                Id = 1,
                Puntaje = 5,
                UsuarioId = 1,
                LibroId = 1,
                Fecha = DateTime.Now.Date
            };
            agregarComentario.Setup(a => a.AddComentario(comentario, usuario));

            sess.Setup(s => s.setNombreUsuario()).Returns(usuario);

            var controller = new LibroController(null, agregarComentario.Object, sess.Object);

            var resultado = controller.AddComentario(comentario);

            Assert.IsInstanceOf<RedirectToRouteResult>(resultado);
        }



    }
}
