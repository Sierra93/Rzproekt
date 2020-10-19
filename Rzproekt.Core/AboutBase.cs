using Microsoft.AspNetCore.Http;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы о нас.
    /// </summary>
    public abstract class AboutBase {
        /// <summary>
        /// Метод получает все данные о нас.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetAboutInfo();

        /// <summary>
        /// Метод изменяет информацию о нас.
        /// </summary>
        /// <param name="filesService"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task ChangeAboutInfo(IFormCollection filesAbout, string jsonString);

        /// <summary>
        /// Метод добавляет сертификаты.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public abstract Task AddCert(IFormCollection filesCert, string jsonString);

        /// <summary>
        /// Метод удаляет сертификат.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task RemoveCert(int id);

        /// <summary>
        /// Метод получает список сертификатов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetCerts();

        /// <summary>
        /// Метод удаляет все сертификаты.
        /// </summary>
        /// <returns></returns>
        public abstract Task RemoveAllCerts();


        /// <summary>
        /// Метод находит сертификаты по тексту.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> SearchCert(string name);

        /// <summary>
        /// Метод добавляет награды.
        /// </summary>
        /// <returns></returns>
        public abstract Task AddAwards(IFormCollection filesCert, string jsonString);

        /// <summary>
        /// Метод удаляет наград.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task RemoveAward(int id);

        /// <summary>
        /// Метод находит награду по тексту.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> SearchAward(string name);
    }
}