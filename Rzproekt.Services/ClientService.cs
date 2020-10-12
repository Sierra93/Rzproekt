using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы работы с клиентами.
    /// </summary>
    public class ClientService : ClientBase {
        ApplicationDbContext _db;

        public ClientService(ApplicationDbContext db) => _db = db;
       
        /// <summary>
        /// Метод получает список клиентов.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetClientsInfo() {
            return await _db.Clients.ToListAsync();
        }

        /// <summary>
        /// Метод добавляет нового клиента.
        /// </summary>
        /// <returns></returns>
        public override Task AddClient() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод изменяет клиента.
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        public async override Task ChangeClientInfo(IFormCollection filesClient, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                ClientDto newOrder = JsonSerializer.Deserialize<ClientDto>(jsonString);

                var isClient = await GetEditClient(newOrder.ClientId);

                if (filesClient.Files.Count > 0) {
                    var path = await common.UploadSingleFile(filesClient);
                    path = path.Replace("wwwroot", "");
                    isClient.Url = path;
                }

                isClient.MainTitle = newOrder.MainTitle;

                _db.Clients.Update(isClient);
                Debugger.Break();

                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод выбирает клиента, которого нужно изменить.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async Task<ClientDto> GetEditClient(int id) {
            return await _db.Clients.Where(o => o.ClientId == id).FirstOrDefaultAsync();
        }
    }
}