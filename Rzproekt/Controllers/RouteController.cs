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
    }
}
