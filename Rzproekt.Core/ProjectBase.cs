using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы работы с проектами.
    /// </summary>
    public abstract class ProjectBase {
        /// <summary>
        /// Метод получает список проектов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetProjectsInfo();

        /// <summary>
        /// Метод добавляет проект.
        /// </summary>
        /// <returns></returns>
        public abstract Task AddProjectInfo(IFormCollection filesMain, IFormCollection filesProject, string jsonString);

        /// <summary>
        /// Метод выводит список проектов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetAllProjects();
    }
}
