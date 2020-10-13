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
                CommonMethodsService common = new CommonMethodsService(_db);
                JObject jsonObject = JObject.Parse(jsonString);
                string mainTitle = jsonObject["MainTitle"].ToString();
                string sText = jsonObject["Text"].ToString();
                string detailMainTitle = jsonObject["detMainTitle"].ToString();
                string detailTitle = jsonObject["detTitle"].ToString();
                string detailText = jsonObject["detText"].ToString();
                AboutDto oAbout = null;

                bool isEmpty = isEmptyStringInfo(mainTitle, sText, detailMainTitle, detailTitle, detailText);

                if (!isEmpty) {
                    throw new ArgumentNullException();
                }

                oAbout = await _db.Abouts.FirstOrDefaultAsync();
                oAbout.MainTitle = mainTitle;
                oAbout.Text = sText;
                oAbout.DopMainTitle = detailMainTitle;
                oAbout.DopTitle = detailTitle;
                oAbout.DopText = detailText;

                _db.Update(oAbout);
                await _db.SaveChangesAsync();                
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
    }
}
