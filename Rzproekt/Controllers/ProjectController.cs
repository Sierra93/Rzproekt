using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу с проектами.
    /// </summary>
    [ApiController, Route("api/project")]
    public class ProjectController : ControllerBase {
        ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db) => db = _db;
        
        /// <summary>
        /// Метод получает список проектов.
        /// </summary>
        [HttpPost, Route("get-projects")]
        public async Task<IActionResult> GetProjectsInfo() {
            ProjectBase projectBase = new ProjectService(_db);

            return Ok(await projectBase.GetProjectsInfo());
        }
    }
}
