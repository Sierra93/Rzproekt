using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /// <param name="filesLogo">Коллекция файлов.</param>
        /// <param name="jsonString">Объект с данными.</param>
        /// <returns></returns>
        public async override Task ChangeHeader(IFormCollection filesLogo, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                //var objParse = JsonSerializer.Serialize(jsonString);
                JObject jsonObject = JObject.Parse(jsonString);

                // Список элементов меню.
                var aMainItems = (JArray)jsonObject["MainItem"];
                var aMainItemsValues = aMainItems.Values().ToList();    // Массив элементов меню хидера.
                string mainTitle = jsonObject["MainTitle"].ToString();  // Заголовок хидера.
                string mainNumber = jsonObject["MainNum"].ToString();   // Номер телефона.

                common.ValidErrorFile(filesLogo.Files.Count);

                // Получает хидер из БД.
                IEnumerable<HeaderDto> aHeaders = await GetHeaders();

                aHeaders.FirstOrDefault().MainTitle = mainTitle;
                aHeaders.FirstOrDefault().MainText = mainNumber;

                int i = 0;
                foreach (var el in aHeaders) {
                    aHeaders.ToList()[i].MainItem = aMainItemsValues[i].ToString();
                    if (i < filesLogo.Files.Count) {                        
                        // Загружает каждый файл в папку.
                        var path = await common.Upload(filesLogo, i);

                        // Записывает в зависимости от расширения файла и обрезает лишнюю часть пути для БД. 
                        if (Path.GetExtension(path) == FileType.VIDEO_MP4) {
                            aHeaders.ToList()[i].Background = path.Replace("wwwroot", "");
                        }

                        if (Path.GetExtension(path) == FileType.IMAGE_PNG) {
                            aHeaders.ToList()[i].Url = path.Replace("wwwroot", "");
                        }                                                                               
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
