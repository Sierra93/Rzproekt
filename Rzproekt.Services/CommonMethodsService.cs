using Microsoft.AspNetCore.Http;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
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
        /// Метод загружает файлы в папку и возвращает путь.
        /// </summary>
        /// <param name="form">Коллекция с файлами.</param>
        /// <returns></returns>

        public async Task<string> Upload(IFormCollection form, int i) {
            try {
                if (form.Files == null || form.Files[0].Length == 0) {
                    throw new ArgumentNullException();
                }

                // Полный локальный путь к файлу включая папку проекта wwwroot.
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), FilePath.STORE_PATH,
                            form.Files[i].FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    await form.Files[i].CopyToAsync(stream);
                }

                //StoreInDB(storePath + form.Files[0].FileName);
                return FilePath.STORE_PATH + form.Files[i].FileName;
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Входные параметры пусты", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод загружает файл в папку и возвращает путь.
        /// </summary>
        /// <param name="form">Коллекция с файлами.</param>
        /// <returns></returns>

        public async Task<string> UploadSingleFile(IFormCollection form) {
            try {
                //if (form.Files == null || form.Files[0].Length == 0) {
                //    throw new ArgumentNullException();
                //}

                // Полный локальный путь к файлу включая папку проекта wwwroot.
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), FilePath.STORE_PATH,
                            form.Files[0].FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    await form.Files[0].CopyToAsync(stream);
                }

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
        /// Метод загружает файлы по одному, исходя из одиночных отправок. Только для модуля О нас.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public async Task<string> UploadSingleFileAbout(IFormFile form) {
            try {
                // Полный локальный путь к файлу включая папку проекта wwwroot.
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), FilePath.STORE_PATH,
                            form.FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    await form.CopyToAsync(stream);
                }

                return FilePath.STORE_PATH + form.FileName;
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Входные параметры пусты", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Проверяет, есть ли файлы.
        /// </summary>
        /// <param name="count"></param>
        public void ValidErrorFile(int count) {
            if (count == 0) {
                throw new ArgumentNullException("Ни один файл не передан");
            }
        }
    }
}
