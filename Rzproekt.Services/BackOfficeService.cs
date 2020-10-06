using Microsoft.AspNetCore.Http;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы админки.
    /// </summary>
    public class BackOfficeService : BackOfficeBase {
        ApplicationDbContext _db;

        public BackOfficeService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод изменяет лого.
        /// </summary>
        /// <returns></returns>
        public async override Task UploadImage(IFormCollection form) {
            try {
                string storePath = "wwwroot/img/";   // Путь к папке с изображениями.

                if (form.Files == null || form.Files[0].Length == 0) {
                    throw new ArgumentNullException();
                }

                // Полный локальный путь к файлу включая папку проекта wwwroot.
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), storePath,
                            form.Files[0].FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    await form.Files[0].CopyToAsync(stream);
                }

                //StoreInDB(storePath + form.Files[0].FileName);
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Входные параметры пусты", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        // Записывает данные в БД.
        async void StoreInDB(string path) {
            
        }
    }
}