using Microsoft.AspNetCore.Http;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует общие методы.
    /// </summary>
    public class CommonMethodsService {
        ApplicationDbContext _db;

        public CommonMethodsService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод загружает файл в папку и возвращает путь.
        /// </summary>
        /// <param name="form">Коллекция с файлами.</param>
        /// <returns></returns>

        public async Task<string> Upload(IFormCollection form) {
            try {
                if (form.Files == null || form.Files[0].Length == 0) {
                    throw new ArgumentNullException();
                }

                //int i = 0;
                //foreach (var el in form.Files) {
                //    i++;
                //}               

                // Полный локальный путь к файлу включая папку проекта wwwroot.
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), FilePath.STORE_PATH,
                            form.Files[0].FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    await form.Files[0].CopyToAsync(stream);
                }

                //StoreInDB(storePath + form.Files[0].FileName);
                return FilePath.STORE_PATH + form.Files[0].FileName;
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Входные параметры пусты", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод загружает файл в папку и записывает путь в БД.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        //public async Task Upload(IFormCollection form) {
        //    CommonMethodsService common = new CommonMethodsService(_db);
        //    await common.Upload(form);
        //}

        //async Task StoreDB(string type) {
        //    switch (type) {
        //        case "header":
        //            _db.Headers
        //            break;
        //    }
        //}
    }
}
