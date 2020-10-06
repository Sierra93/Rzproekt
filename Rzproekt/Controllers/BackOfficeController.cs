using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core.Data;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу с админкой.
    /// </summary>
    [ApiController, Route("api/back-office")]
    public class BackOfficeController : ControllerBase {
        ApplicationDbContext _db;

        public BackOfficeController(ApplicationDbContext db) => _db = db;
    }
}
