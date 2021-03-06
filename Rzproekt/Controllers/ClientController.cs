﻿using System;
using System.Collections;
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
    /// Контроллер описывает работу с клиентами.
    /// </summary>
    [ApiController, Route("api/client")]
    public class ClientController : ControllerBase {
        ApplicationDbContext _db;

        public ClientController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает список клиентов.
        /// </summary>
        [HttpPost, Route("get-clients")]
        public async Task<IActionResult> GetClientsInfo() {
            ClientBase clientBase = new ClientService(_db);
            var oClients = await clientBase.GetClientsInfo();

            return Ok(oClients);
        }

        /// <summary>
        /// Метод ищет сертификат по тексту.
        /// </summary>
        [HttpPost, Route("search")]
        public async Task<IActionResult> SearchClient([FromBody] ClientDto certDto) {
            ClientBase clientBase = new ClientService(_db);
            var aoClient = await clientBase.SearchClient(certDto.ClientName);

            return Ok(aoClient);
        }
    }
}
