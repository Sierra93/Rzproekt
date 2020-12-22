using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу с админкой.
    /// </summary>
    [ApiController, Route("api/back-office")]
    public class BackOfficeController : ControllerBase {
        ApplicationDbContext _db;

        public BackOfficeController(ApplicationDbContext db) => _db = db;
  
        /// <summary>
        /// Метод изменяет хидер.
        /// </summary>
        [HttpPost, Route("change-header")]
        //[RequestSizeLimit(100_000_000)]
        //[RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        //[RequestSizeLimit(409715200)]
        public async Task<IActionResult> ChangeHeader([FromForm] IFormCollection filesLogo, [FromForm] string jsonString) {
            HeaderBase backOfficeBase = new HeaderService(_db);
            await backOfficeBase.ChangeHeader(filesLogo, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет данные услуг.
        /// </summary>
        [HttpPost, Route("change-order")]
        public async Task<IActionResult> ChangeOrder([FromForm] IFormCollection filesService, [FromForm] string jsonString) {
            OrderBase orderBase = new OrderService(_db);
            await orderBase.ChangeOrder(filesService, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет полную информацию о нас.
        /// </summary>
        [HttpPost, Route("change-about")]
        public async Task<IActionResult> ChangeMainAbout([FromForm] IFormCollection filesAbout, [FromForm] string jsonString) {
            AboutBase aboutBase = new AboutService(_db);
            await aboutBase.ChangeMainAboutInfo(filesAbout, jsonString);

            return Ok();
        }

        [HttpPost, Route("change-detail-about")]
        public async Task<IActionResult> ChangeDetailAbout([FromForm] IFormCollection filesDopAbout, [FromForm] string jsonString) {
            AboutBase aboutBase = new AboutService(_db);
            await aboutBase.ChangeDetailAboutInfo(filesDopAbout, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод добавляет клиента.
        /// </summary>
        [HttpPost, Route("add-client")]
        public async Task<IActionResult> AddClient([FromForm] IFormCollection filesClient, [FromForm] string jsonString) {
            ClientBase clientBase = new ClientService(_db);
            await clientBase.AddClient(filesClient, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет клиента.
        /// </summary>
        [HttpPost, Route("change-client")]
        public async Task<IActionResult> ChangeClientInfo([FromForm] IFormCollection filesClient, [FromForm] string jsonString) {
            ClientBase clientBase = new ClientService(_db);
            await clientBase.ChangeClientInfo(filesClient, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод удаляет клиента.
        /// </summary>
        [HttpPut, Route("remove-client")]
        public async Task<IActionResult> DeleteClient([FromQuery] int id) {
            ClientBase clientBase = new ClientService(_db);
            await clientBase.DeleteClient(id);

            return Ok();
        }

        /// <summary>
        /// Метод добавляет сертификаты.
        /// </summary>
        [HttpPost, Route("add-cert")]
        public async Task<IActionResult> AddCert([FromForm] IFormCollection filesCert, [FromForm] string jsonString) {
            AboutBase cert = new AboutService(_db);
            await cert.AddCert(filesCert, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод получает список сертификатов.
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("get-certs")]
        public async Task<IActionResult> GetCerts() {
            AboutBase cert = new AboutService(_db);

            return Ok(await cert.GetCerts());
        }

        /// <summary>
        /// Метод удаляет все сертификаты.
        /// </summary>
        /// <returns></returns>
        [HttpPut, Route("remove-certs")]
        public async Task<IActionResult> RemoveAllCerts() {
            AboutBase cert = new AboutService(_db);
            await cert.RemoveAllCerts();

            return Ok();
        }

        /// <summary>
        /// Метод удаляет сертификат.
        /// </summary>
        /// <returns></returns>
        [HttpPut, Route("remove-cert")]
        public async Task<IActionResult> RemoveCert([FromQuery] int id) {
            AboutBase cert = new AboutService(_db);
            await cert.RemoveCert(id);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет данные статистики.
        /// </summary>
        [HttpPost, Route("change-stat")]
        public async Task<IActionResult> ChangeStatistic([FromBody] object data) {
            StatisticBase statis = new StatisticService(_db);
            await statis.ChangeStatistic(data);

            return Ok();
        }

        /// <summary>
        /// Метод добавляет новый проект.
        /// </summary>
        [HttpPost, Route("add-project")]
        public async Task<IActionResult> AddProjectInfo([FromForm] IFormCollection filesProject, [FromForm] string jsonString) {
            ProjectBase projectBase = new ProjectService(_db);
            await projectBase.AddProjectInfo(filesProject, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод удаляет проект.
        /// </summary>
        [HttpHead, Route("remove-project/{id}")]
        public async Task<IActionResult> RemoveProject([FromRoute] int id) {
            ProjectBase projectBase = new ProjectService(_db);
            await projectBase.RemoveProject(id);

            return Ok();
        }

        /// <summary>
        /// Метод добавляет награды.
        /// </summary>
        [HttpPost, Route("add-award")]
        public async Task<IActionResult> AddAwards([FromForm] IFormCollection filesCert, [FromForm] string jsonString) {
            AboutBase award = new AboutService(_db);
            await award.AddAwards(filesCert, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод удаляет награды.
        /// </summary>
        [HttpPut, Route("remove-award")]
        public async Task<IActionResult> RemoveAward([FromQuery] int id) {
            AboutBase award = new AboutService(_db);
            await award.RemoveAward(id);

            return Ok();
        }

        /// <summary>
        /// Метод добавляет контакты компании.
        /// </summary>
        [HttpPost, Route("change-contact-company")]
        public async Task<IActionResult> ChangeContactCompany([FromBody] ContactCompanyDto contactCompanyDto) {
            ContactBase contactBase = new ContactService(_db);
            await contactBase.AddContactCompany(contactCompanyDto);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет контакты руководителя.
        /// </summary>
        [HttpPost, Route("change-contact-lead")]
        public async Task<IActionResult> ChangeContactLead([FromForm] IFormCollection filesContact, [FromForm] string jsonString) {
            ContactBase contactBase = new ContactService(_db);
            await contactBase.ChangeContactLead(filesContact, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод добавляет контакты руководителя.
        /// </summary>
        [HttpPost, Route("add-contact-lead")]
        public async Task<IActionResult> AddContactLead([FromForm] IFormCollection filesContact, [FromForm] string jsonString) {
            ContactBase contactBase = new ContactService(_db);
            await contactBase.AddContactLead(filesContact, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод удаляет награды.
        /// </summary>
        [HttpPut, Route("remove-lead")]
        public async Task<IActionResult> RemoveLead([FromQuery] int id) {
            ContactBase contact = new ContactService(_db);
            await contact.RemoveLead(id);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет проект.
        /// </summary>
        [HttpPost, Route("change-project")]
        public async Task<IActionResult> ChangeProjectInfo([FromBody] ProjectDto projectDto) {
            ProjectBase projectBase = new ProjectService(_db);
            await projectBase.ChangeProjectInfo(projectDto);

            return Ok();
        }

        /// <summary>
        /// Метод выводит список наград.
        /// </summary>
        [HttpPost, Route("get-awards")]
        public async Task<IActionResult> GetAwards() {
            AboutBase aboutBase = new AboutService(_db);

            return Ok(await aboutBase.GetAwards());
        }
    }
}