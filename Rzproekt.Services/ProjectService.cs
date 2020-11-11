using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
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
        /// Метод получает список проектов.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetProjectsInfo() {
            return await _db.Projects.Take(3).ToListAsync();
        }

        /// <summary>
        /// Метод добавляет проект.
        /// </summary>
        /// <returns></returns>
        public async override Task AddProjectInfo(IFormCollection filesProjectMain, IFormCollection filesProject, string jsonString) {
            try {
                // Ждет выполнения главной таблицы проектов.
                Task taskMainTable = Task.Run(async () => await AddMainProject(filesProjectMain, jsonString));
                taskMainTable.Wait();

                // Ждет выполнение добавления дополнительных изображений.
                Task taskDetailTable = Task.Run(async () => await AddDetailProject(filesProject));
                taskDetailTable.Wait();
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
        async Task AddMainProject(IFormCollection filesProjectMain, string jsonString) {
            CommonMethodsService common = new CommonMethodsService(_db);
            ProjectDto projectDto = JsonSerializer.Deserialize<ProjectDto>(jsonString);

            if (filesProjectMain.Files.Count > 0) {
                string path = await common.UploadSingleFile(filesProjectMain);
                path = path.Replace("wwwroot", "");
                projectDto.Url = path;
            }

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

        /// <summary>
        /// Метод добавляет проект в дополнительную таблицу.
        /// </summary>
        /// <param name="filesProject"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        async Task AddDetailProject(IFormCollection filesProject) {
            CommonMethodsService common = new CommonMethodsService(_db);
            ProjectDetailDto projectDetailsDto = new ProjectDetailDto();

            if (filesProject.Files.Count > 0) {
                string path = await common.UploadSingleFile(filesProject);
                path = path.Replace("wwwroot", "");
                projectDetailsDto.Url = path;
            }

            if (Convert.ToBoolean(projectDetailsDto.IsMain)) {
                projectDetailsDto.IsMain = "true";
            }
            else {
                projectDetailsDto.IsMain = "false";
            }

            // Находит Id последнего проекта.
            int lastId = await GetLastProject();

            // Добавляет в таблицу деталей.
            await AddProjectDetail(lastId, filesProject, projectDetailsDto.IsMain);
        }

        /// <summary>
        /// Метод находит последний добавленный проект.
        /// </summary>
        /// <returns></returns>
        async Task<int> GetLastProject() {
            return await _db.Projects.OrderByDescending(p => p.ProjectId).Select(p => p.ProjectId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Метод добавляет детальную информацию о проекте.
        /// </summary>
        /// <returns></returns>
        async Task AddProjectDetail(int id, IFormCollection filesProject, string isMain) {
            CommonMethodsService common = new CommonMethodsService(_db);
            ProjectDetailDto projectDetailDto = new ProjectDetailDto();

            if (filesProject.Files.Count > 0) {
                string path = await common.UploadSingleFile(filesProject);
                path = path.Replace("wwwroot", "");
                projectDetailDto.Url = path;
            }
            projectDetailDto.ProjectId = id;
            projectDetailDto.IsMain = isMain;

            await _db.DetailProjects.AddAsync(projectDetailDto);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Метод выводит список проектов.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetAllProjects() {
            return await _db.Projects.ToListAsync();
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

                _db.Remove(oProject);
                await _db.SaveChangesAsync();
            }

            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Id не передан", ex.Message.ToString());
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
                // Берет старый путь к изображению.
                string oldProject = await _db.Projects.Where(p => p.ProjectId == projectDto.ProjectId).Select(p => p.Url).FirstOrDefaultAsync();

                projectDto.Block = BlockType.PROJECT;
                projectDto.Url = oldProject;
                _db.Projects.Update(projectDto);
                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async override Task<IList> GetAllProjectsWithUrl() {
            try {
                IList aProjects = await _db.Projects.Join(_db.DetailProjects,
                    t1 => t1.ProjectId,
                    t2 => t2.ProjectId,
                    (t1, t2) => new {
                        id = t1.ProjectId,
                        projectName = t1.ProjectName,
                        url = t1.Url,
                        urlDetail = t2.Url
                    }).ToListAsync();

                //IList aProjects = await _db.Projects.Join(_db.DetailProjects,
                //   t1 => t1.ProjectId,
                //   t2 => t2.ProjectId,
                //   (t1, t2) => new {
                //       id = t1.ProjectId,
                //       projectName = t1.ProjectName,
                //       url = t1.Url,
                //       urlDetail = new string[] { t2.Url }
                //   }).Select(s => new {
                //       id = s.id,
                //       projectName = s.projectName,
                //       url = s.url,
                //       urlDetail = new string[] { s.url }
                //   }).Distinct().ToListAsync();

                return aProjects;
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}