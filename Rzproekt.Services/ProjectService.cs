using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы работы с проектами.
    /// </summary>
    public class ProjectService : ProjectBase {
        ApplicationDbContext _db;

        public ProjectService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает список всех проектов либо 3-х.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetProjectsInfo() {
            try
            {
                return await GetCountProjects() >= 3 ? await GetThreeProjects() :
                       await GetProjects();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private async Task<IEnumerable> GetThreeProjects()
        {
            return await _db.Projects.Where(p => p.IsMain.Equals("true")).Take(3).ToListAsync();
        }

        /// <summary>
        /// Метод получит кол-во проектов с true.
        /// </summary>
        /// <returns></returns>
        private async Task<int> GetCountProjects()
        {
            return await _db.Projects.Where(p => p.IsMain.Equals("true")).CountAsync();
        }

        /// <summary>
        /// Метод добавляет проект.
        /// </summary>
        /// <returns></returns>
        public async override Task AddProjectInfo(IFormCollection filesProject, string jsonString) {
            try {
                await AddProject(filesProject, jsonString);
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод добавляет проекты в главную таблицу.
        /// </summary>
        /// <param name="filesProject"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        async Task AddProject(IFormCollection filesProject, string jsonString) {
            ProjectDto projectDto = JsonSerializer.Deserialize<ProjectDto>(jsonString);

            // Если добавлять один файл.
            if (filesProject.Files.Count > 0 && filesProject.Files.Count == 1) {
                await AddSingleFile(filesProject, projectDto);
            }

            // Если добавлять несколько файлов.
            if (filesProject.Files.Count > 1) {
                await AddMultiFileProject(filesProject, projectDto);
            }
        }

        /// <summary>
        /// Метод добавляет одно фото проекта в основную таблицу.
        /// </summary>
        /// <param name="filesProject"></param>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        async Task AddSingleFile(IFormCollection filesProject, ProjectDto projectDto) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                string path = await common.UploadSingleFile(filesProject);
                path = path.Replace("wwwroot", "");
                projectDto.Url = path;

                if (Convert.ToBoolean(projectDto.IsMain)) {
                    projectDto.IsMain = "true";
                }

                else {
                    projectDto.IsMain = "false";
                }

                projectDto.Block = BlockType.PROJECT;
                projectDto.ButtonText = ButtonType.BTN_DETAIL;

                await _db.Projects.AddAsync(projectDto);
                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод добавляет первое фото в основную таблицу, остальные в дополнительную.
        /// </summary>
        /// <param name="filesProject"></param>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        async Task AddMultiFileProject(IFormCollection filesProject, ProjectDto projectDto) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);                
                int categoryId = 0;

                for (int i = 0; i < filesProject.Files.Count; i++) {
                    ProjectDetailDto projectDetailDto = new ProjectDetailDto();
                    string path = await common.Upload(filesProject, i);
                    path = path.Replace("wwwroot", "");
                    projectDetailDto.Url = path;
                    projectDetailDto.IsMain = projectDto.IsMain;

                    // Добавляет первое фото.
                    if (i < 1) {
                        projectDto.Url = path;
                        if (Convert.ToBoolean(projectDto.IsMain)) {
                            projectDto.IsMain = "true";
                        }

                        else {
                            projectDto.IsMain = "false";
                        }

                        projectDto.Block = BlockType.PROJECT;
                        projectDto.ButtonText = ButtonType.BTN_DETAIL;
                        projectDto.MainTitle = projectDto.MainTitle;
                        projectDto.ProjectDetail = projectDto.ProjectDetail;
                        projectDto.ProjectName = projectDto.ProjectName;

                        // Находит Id последнего проекта.
                        await _db.Projects.AddAsync(projectDto);
                        await _db.SaveChangesAsync();
                        categoryId = await GetLastProject();
                    }

                    if (Convert.ToBoolean(projectDetailDto.IsMain)) {
                        projectDetailDto.IsMain = "true";
                    }

                    else {
                        projectDetailDto.IsMain = "false";
                    }

                    projectDetailDto.Url = path;
                    projectDetailDto.ProjectId = categoryId;
                    await _db.DetailProjects.AddRangeAsync(projectDetailDto);                   
                }

                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод добавляет проект в дополнительную таблицу.
        /// </summary>
        /// <param name="filesProject"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        //async Task AddDetailProject(IFormCollection filesProject) {
        //    CommonMethodsService common = new CommonMethodsService(_db);
        //    ProjectDetailDto projectDetailsDto = new ProjectDetailDto();

        //    if (filesProject.Files.Count > 0) {
        //        string path = await common.UploadSingleFile(filesProject);
        //        path = path.Replace("wwwroot", "");
        //        projectDetailsDto.Url = path;
        //    }

        //    if (Convert.ToBoolean(projectDetailsDto.IsMain)) {
        //        projectDetailsDto.IsMain = "true";
        //    }
        //    else {
        //        projectDetailsDto.IsMain = "false";
        //    }

        //    // Находит Id последнего проекта.
        //    int lastId = await GetLastProject();

        //    // Добавляет в таблицу деталей.
        //    await AddProjectDetail(lastId, filesProject, projectDetailsDto.IsMain);
        //}

        /// <summary>
        /// Метод находит последний добавленный проект.
        /// </summary>
        /// <returns></returns>
        async Task<int> GetLastProject() {
            return await _db.Projects.OrderByDescending(p => p.ProjectId).Select(p => p.ProjectId).FirstOrDefaultAsync();
        }

        //async Task<int> GetLastProjectId() {
        //    int id = await _db.Projects.OrderByDescending(p => p.CategoryProject).Select(p => p.CategoryProject).FirstOrDefaultAsync();
        //    id++;

        //    return id;
        //}

        /// <summary>
        /// Метод добавляет детальную информацию о проекте.
        /// </summary>
        /// <returns></returns>
        //async Task AddProjectDetail(int id, IFormCollection filesProject, string isMain) {
        //    CommonMethodsService common = new CommonMethodsService(_db);
        //    ProjectDetailDto projectDetailDto = new ProjectDetailDto();

        //    if (filesProject.Files.Count > 0) {
        //        string path = await common.UploadSingleFile(filesProject);
        //        path = path.Replace("wwwroot", "");
        //        projectDetailDto.Url = path;
        //    }
        //    projectDetailDto.ProjectId = id;
        //    projectDetailDto.IsMain = isMain;

        //    await _db.DetailProjects.AddAsync(projectDetailDto);
        //    await _db.SaveChangesAsync();
        //}

        /// <summary>
        /// Метод выводит список проектов, если их больше 3 с галочками.
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable> GetProjects()
        {
            return await _db.Projects.Where(p => p.IsMain.Equals("true")).ToListAsync();
        }

        /// <summary>
        /// Метод удаляет проект.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async override Task RemoveProject(int id) {
            try {
                if (id == 0) {
                    throw new ArgumentNullException();
                }

                ProjectDto oProject = await _db.Projects.Where(p => p.ProjectId == id).FirstOrDefaultAsync();

                bool bLastProject = await ChecLastProject();

                if (bLastProject)
                {
                    throw new ArgumentException();
                }

                _db.Projects.Remove(oProject);

                IList<ProjectDetailDto> aProjectsDetails = await _db.DetailProjects
                    .Where(d => d.ProjectId == oProject.ProjectId)
                    .ToListAsync();

                _db.DetailProjects.RemoveRange(aProjectsDetails);
                await _db.SaveChangesAsync();
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Id не передан", ex.Message.ToString());
            }

            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Нельзя удалить последний проект {ex.Message}");
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод изменяет проект.
        /// </summary>
        /// <returns></returns>
        public async override Task ChangeProjectInfo(ProjectDto projectDto) {
            try {
                bool bMainFlag = await GetCountProjects() < 3;

                if (bMainFlag)
                {
                    throw new ArgumentException();
                }

                // Берет старый путь к изображению.
                string oldProject = await _db.Projects.Where(p => p.ProjectId == projectDto.ProjectId).Select(p => p.Url).FirstOrDefaultAsync();

                projectDto.Block = BlockType.PROJECT;
                projectDto.Url = oldProject;
                _db.Projects.Update(projectDto);
                await _db.SaveChangesAsync();
            }

            catch (ArgumentException ex)
            {
                throw new ArgumentException($"недопустимо наличие менее 3 главных проектов {ex.Message}");
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод получает список проектов вместе с фото каждого проекта.
        /// </summary>
        public async override Task<IList<ProjectDto>> GetAllProjects() {
            try {
                IList<ProjectDto> aProjects = await _db.Projects.ToListAsync();

                return aProjects;
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод получает все фото проекта.
        /// </summary>
        /// <returns></returns>
        public async override Task<IList<ProjectDetailDto>> GetProject(int projectId) {
            return await _db.DetailProjects.Where(p => p.ProjectId.Equals(projectId)).ToListAsync();
        }

        public async override Task<IEnumerable> GetProjectPhotos(int projectId) {
            try {
                return await _db.DetailProjects.Where(p => p.ProjectId.Equals(projectId)).ToListAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод проверяет, последний ли проект в БД. Если да, то не даст удалить.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ChecLastProject()
        {
            try
            {
                return await _db.Projects.CountAsync() <= 3;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}