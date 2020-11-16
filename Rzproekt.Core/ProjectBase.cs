using Microsoft.AspNetCore.Http;
using Rzproekt.Models;
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
        public abstract Task AddProjectInfo(IFormCollection filesProject, string jsonString);

        /// <summary>
        /// Метод выводит список проектов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IList<ProjectDto>> GetAllProjects();

        /// <summary>
        /// Метод удаляет проект.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task RemoveProject(int id);

        /// <summary>
        /// Метод изменяет проект.
        /// </summary>
        /// <returns></returns>
        public abstract Task ChangeProjectInfo(ProjectDto projectDto);

        /// <summary>
        /// Метод получает все фото проекта.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IList<ProjectDetailDto>> GetProject(int projectId);
    }
}
