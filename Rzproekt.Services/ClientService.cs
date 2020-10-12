using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        /// Метод изменяет клиента.
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        public async override Task ChangeClientInfo(IFormCollection filesClient, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                ClientDto newOrder = JsonSerializer.Deserialize<ClientDto>(jsonString);
                ClientDto isClient = null;
               

                if (filesClient.Files.Count > 0) {
                    var path = await common.UploadSingleFile(filesClient);
                    path = path.Replace("wwwroot", "");

                    isClient = await GetEditClient(newOrder.ClientId);
                    isClient.Url = path;
                }

                if (filesClient.Files.Count == 0 && !string.IsNullOrEmpty(newOrder.MainTitle))
                {
                    isClient =  await _db.Clients.FirstOrDefaultAsync();
                    isClient.MainTitle = newOrder.MainTitle;
                }

               // isClient.MainTitle = newOrder.MainTitle;

                _db.Clients.Update(isClient);

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

        /// <summary>
        /// Метод удаляет клиента.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async override Task DeleteClient(int id) {
            try {
                if (id == 0) {
                    throw new ArgumentNullException();
                }

                ClientDto client = await _db.Clients.Where(c => c.ClientId == id).FirstOrDefaultAsync();

                _db.Clients.RemoveRange(client);
                await _db.SaveChangesAsync();
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Id не передан", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод добавляет нового клиента.
        /// </summary>
        /// <returns></returns>
        public async override Task AddClient(IFormCollection filesClient) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                ClientDto client = new ClientDto();

                if (filesClient.Files.Count > 0) {
                    var path = await common.UploadSingleFile(filesClient);
                    path = path.Replace("wwwroot", "");
                    client.Url = path;
                    client.Block = BlockType.CLIENT;
                }

                _db.Clients.Update(client);

                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод получает кол-во клиентов.
        /// </summary>
        /// <returns></returns>
        public async override Task<int> GetClientCount() {
            try {
                return await _db.Clients.CountAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}