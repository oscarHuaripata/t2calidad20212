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
      public class AuthControllerTest
    {
        [Test]
        public void DebePoderIngresarUsuario()
        {
            string Username = "aaaaaa";
            string Password = "admin";

            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombres = "Oscar",
                Password = "admin",
                Username = "admin"
            };

            var login = new Mock<IUsuarioSession>();
            var login2 = new Mock<IUsuario>();

            login2.Setup(p => p.GetUsuario(Username, Password)).Returns(usuario);

            login.Setup(a => a.AutenticaUsername(Username, true));

            var controller = new AuthController(login2.Object, login.Object);


            var rederit = controller.Login(Username, Password);

            Assert.IsInstanceOf<RedirectToRouteResult>(rederit);
            Assert.IsNotInstanceOf<ViewResult>(rederit);

        }

    }


}
