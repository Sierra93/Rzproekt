using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает роуты приложения.
    /// </summary>
    public class RouteController : Controller {
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// Метод переходит на главную страницу.
        /// </summary>
        /// <returns></returns>
        public IActionResult onMain() {
            return View("Index");
        }

        /// <summary>
        /// Метод переходит на страницу админки.
        /// </summary>
        /// <returns></returns>
        [Route("back-office")]
        public IActionResult BackOffice() {
            return View();
        }

        /// <summary>
        /// Метод переходит на страницу авторизации перед админкой.
        /// </summary>
        /// <returns></returns>
        [Route("admin")]
        public IActionResult LogOn() {
            return View();
        }

        /// <summary>
        /// Метод переходит на страницу детальной информации о компании.
        /// </summary>
        /// <returns></returns>
        [Route("about-details")]
        public IActionResult AboutDetails() {
            return View();
        }

        /// <summary>
        /// Метод переходит на страницу деталей проектов.
        /// </summary>
        /// <returns></returns>
        [Route("project-details")]
        public IActionResult ProjectDetails() {
            return View();
        }

        /// <summary>
        /// Метод переходит на страницу контактов.
        /// </summary>
        /// <returns></returns>
        [Route("contact-details")]
        public IActionResult ContactDetails() {
            return View();
        }

        /// <summary>
        /// Метод переходит на страницу контактов.
        /// </summary>
        /// <returns></returns>
        [Route("test")]
        public IActionResult Test() {
            return View();
        }
    }
}
