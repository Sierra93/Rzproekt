using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу с проектами.
    /// </summary>
    [ApiController, Route("api/project")]
    public class ProjectController : ControllerBase {
        ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает первые три проекта.
        /// </summary>
        [HttpPost, Route("get-projects")]
        public async Task<IActionResult> GetProjectsInfo() {
            ProjectBase projectBase = new ProjectService(_db);

            return Ok(await projectBase.GetProjectsInfo());
        }

        /// <summary>
        /// Метод получает список проектов.
        /// </summary>
        [HttpPost, Route("all-projects")]
        public async Task<IActionResult> GetAllProjects() {
            ProjectBase projectBase = new ProjectService(_db);
            var aProjects = await projectBase.GetAllProjects();

            return Ok(aProjects);
        }

        /// <summary>
        /// Метод получает проект по Id.
        /// </summary>
        [HttpPost, Route("get-project")]
        public async Task<IActionResult> GetProject([FromBody] ProjectDto projectDto) {
            ProjectBase projectBase = new ProjectService(_db);
            var aProjects = await projectBase.GetProject(projectDto.ProjectId);

            return Ok(aProjects);
        }

        /// <summary>
        /// Метод выводит фото проекта.
        /// </summary>
        [HttpGet, Route("collection/{id}")]
        public async Task<IActionResult> GetProjectPhotos([FromRoute] int id) {
            ProjectBase projectBase = new ProjectService(_db);

            return Ok(await projectBase.GetProjectPhotos(id));
        }
    }
}
