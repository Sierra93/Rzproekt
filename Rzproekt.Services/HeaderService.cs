using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы хидера.
    /// </summary>
    public class HeaderService : HeaderBase {
        ApplicationDbContext _db;

        public HeaderService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает данные хидера.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetHeaderInfo() {
            return await _db.Headers.ToListAsync();
        }

        /// <summary>
        /// Метод изменяет хидер.
        /// </summary>
        /// <param name="headerDto"></param>
        /// <returns></returns>
        public async override Task ChangeHeader(IFormCollection filesLogo, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                //var objParse = JsonSerializer.Serialize(jsonString);
                JObject jsonObject = JObject.Parse(jsonString);

                // Список элементов меню.
                var aMainItems = (JArray)jsonObject["MainItem"];
                var aMainItemsValues = aMainItems.Values().ToList();
                string mainTitle = jsonObject["MainTitle"].ToString();

                // Получает хидер из БД.
                IEnumerable<HeaderDto> aHeaders = await GetHeaders();
                aHeaders.ToList()[0].MainTitle = mainTitle;

                int i = 0;
                foreach (var el in aHeaders) {
                    aHeaders.ToList()[i].MainItem = aMainItemsValues[i].ToString();
                    if (i < filesLogo.Files.Count) {                        
                        // Загружает каждый файл в папку.
                        var path = await common.Upload(filesLogo, i);

                        // ОБрезает лишнюю часть пути для БД.                    
                        aHeaders.ToList()[i].Url = path.Replace("wwwroot", "");
                        
                    }
                    _db.Headers.UpdateRange(aHeaders);
                    i++;
                }
                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод получает хидер из БД.
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<HeaderDto>> GetHeaders() {
            return await _db.Headers.ToListAsync();
        }
    }
}
