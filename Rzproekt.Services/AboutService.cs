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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы о нас.
    /// </summary>
    public class AboutService : AboutBase {
        ApplicationDbContext _db;

        public AboutService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает все данные о нас.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetAboutInfo() {
            return await _db.Abouts.ToListAsync();
        }

        /// <summary>
        /// Метод изменяет информацию о нас.
        /// </summary>
        /// <param name="filesService"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public async override Task ChangeAboutInfo(IFormCollection filesAbout, string jsonString) {
            try {                         
                JObject jsonObject = JObject.Parse(jsonString);

                string mainTitle = jsonObject["MainTitle"].ToString();
                string sText = jsonObject["Text"].ToString();
                string detailMainTitle = jsonObject["detMainTitle"].ToString();
                string detailTitle = jsonObject["detTitle"].ToString();
                string detailText = jsonObject["detText"].ToString();

                // Сохранять изображение для главной страницы.
                bool mainImage = Convert.ToBoolean(jsonObject["mainImg"].ToString());

                // Сохранять изображение для дополнительной страницы.
                bool detailImage = Convert.ToBoolean(jsonObject["detImg"].ToString());                
                bool isEmpty = isEmptyStringInfo(mainTitle, sText, detailMainTitle, detailTitle, detailText);

                if (!isEmpty) {
                    throw new ArgumentNullException();
                }                

                await AddAboutInfo(mainTitle, sText, detailMainTitle, detailTitle, detailText, mainImage, detailImage, filesAbout);     
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Не все поля заполнены", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод валидирует поля с информацией о нас.
        /// </summary>
        /// <returns></returns>
        bool isEmptyStringInfo(string mainTitle, string sText, string detailMainTitle, string detailTitle, string detailText) {
            if (!string.IsNullOrEmpty(mainTitle) &&
                !string.IsNullOrEmpty(sText) &&
                !string.IsNullOrEmpty(detailMainTitle) &&
                !string.IsNullOrEmpty(detailTitle) &&
                !string.IsNullOrEmpty(detailText)) {

                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод добавляет информацию о нас в БД.
        /// </summary>
        /// <returns></returns>
        async Task AddAboutInfo(string mainTitle, string sText, string detailMainTitle, string detailTitle, string detailText, bool detailImage, bool mainImage, IFormCollection filesAbout) {
            AboutDto oAbout = null;
            CommonMethodsService common = new CommonMethodsService(_db);
            oAbout = await _db.Abouts.FirstOrDefaultAsync();
            oAbout.MainTitle = mainTitle;
            oAbout.Text = sText;
            oAbout.DopMainTitle = detailMainTitle;
            oAbout.DopTitle = detailTitle;
            oAbout.DopText = detailText;

            // Какое изображение нужно добавить (основное или дополнительное).
            if (mainImage) {
                string path = await common.UploadSingleFile(filesAbout);
                path = path.Replace("wwwroot", "");
                oAbout.Url = path;
            }

            if (detailImage) {
                string path = await common.UploadSingleFile(filesAbout);
                path = path.Replace("wwwroot", "");
                oAbout.DopUrl = path;
            }
            
            _db.Update(oAbout);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Метод добавляет сертификаты.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async override Task AddCert(IFormCollection filesCert, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                JObject jsonParse = JObject.Parse(jsonString);
                string certName = jsonParse["nameCert"].ToString();

                if (filesCert.Files.Count == 0) {
                    throw new ArgumentNullException();
                }

                // Итеративно добавляет сертификаты.
                //int i = 0;
                //filesCert.ToList().ForEach(async el => {
                //    var path = await common.Upload(filesCert, i);
                //    path = path.Replace("wwwroot", "");
                //    cert.Url = path;
                //    await _db.Certs.AddRangeAsync(cert);
                //    i++;
                //});
                var path = await common.UploadSingleFile(filesCert);
                path = path.Replace("wwwroot", "");

                CertDto cert = new CertDto() { Url = path, Block = BlockType.CERT };

                // Если есть имя сертификата.
                if (!string.IsNullOrEmpty(certName)) {
                    cert.CertName = certName;
                }

                await _db.Certs.AddRangeAsync(cert);
                await _db.SaveChangesAsync();
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Нет файлов для добавления", ex.Message.ToString());
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод удаляет сертификат.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task RemoveCert(int id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод получает список сертификатов.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetCerts() {
            return await _db.Certs.ToListAsync();
        }

        /// <summary>
        /// Метод удаляет все сертификаты.
        /// </summary>
        /// <returns></returns>
        public async override Task RemoveAllCerts() {
            IEnumerable<CertDto> certs = await _db.Certs.ToListAsync();
            _db.RemoveRange(certs);
        }
    }
}
