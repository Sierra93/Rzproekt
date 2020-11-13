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
                ProjectDetailDto projectDetailDto = new ProjectDetailDto();
                int categoryId = 0;

                for (int i = 0; i < filesProject.Files.Count; i++) {
                    ProjectDto projectDto1 = new ProjectDto();
                    string path = await common.Upload(filesProject, i);
                    path = path.Replace("wwwroot", "");
                    projectDetailDto.Url = path;
                    projectDto1.IsMain = projectDto.IsMain;

                    // Добавляет первое фото.
                    if (i < 1) {
                        projectDto1.Url = path;
                        if (Convert.ToBoolean(projectDto1.IsMain)) {
                            projectDto1.IsMain = "true";
                        }

                        else {
                            projectDto1.IsMain = "false";
                        }

                        projectDto1.Block = BlockType.PROJECT;
                        projectDto1.ButtonText = ButtonType.BTN_DETAIL;
                        projectDto1.MainTitle = projectDto.MainTitle;
                        projectDto1.ProjectDetail = projectDto.ProjectDetail;
                        projectDto1.ProjectName = projectDto.ProjectName;
                        categoryId = await GetLastProjectId();
                        projectDto1.CategoryProject = categoryId;
                        await _db.Projects.AddAsync(projectDto1);
                        //await _db.SaveChangesAsync();               
                        Debugger.Break();
                    }

                    if (Convert.ToBoolean(projectDto1.IsMain)) {
                        projectDto1.IsMain = "true";
                    }

                    else {
                        projectDto1.IsMain = "false";
                    }

                    projectDto1.Url = path;
                    projectDto1.Block = BlockType.PROJECT;
                    projectDto1.ButtonText = ButtonType.BTN_DETAIL;
                    //categoryId = await GetLastProjectId();
                    projectDto1.CategoryProject = categoryId;
                    await _db.Projects.AddRangeAsync(projectDto1);

                    #region Старая версия.
                    //int i = 0;
                    //for (int i = 0; i < filesProject.Files.Count; i++) {
                    //    if (i < filesProject.Files.Count) {
                    //        string path = await common.Upload(filesProject, i);
                    //        path = path.Replace("wwwroot", "");
                    //        projectDetailDto.Url = path;

                    //        // Берет первое фото.
                    //        if (i < 1) {
                    //            projectDto.Url = path;
                    //            if (Convert.ToBoolean(projectDto.IsMain)) {
                    //                projectDto.IsMain = "true";
                    //            }

                    //            else {
                    //                projectDto.IsMain = "false";
                    //            }

                    //            projectDto.Block = BlockType.PROJECT;
                    //            projectDto.ButtonText = ButtonType.BTN_DETAIL;
                    //            await _db.Projects.AddAsync(projectDto);
                    //            await _db.SaveChangesAsync();

                    //            lastId = await GetLastProject();
                    //        }

                    //        projectDetailDto.ProjectId = lastId;

                    //        // Остальные фото.
                    //        if (Convert.ToBoolean(projectDto.IsMain)) {
                    //            projectDetailDto.IsMain = "true";
                    //        }

                    //        else {
                    //            projectDetailDto.IsMain = "false";
                    //        }                        
                    //        //i++;
                    //    }
                    //    await _db.DetailProjects.AddAsync(projectDetailDto);
                    //}  
                    #endregion
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

        async Task<int> GetLastProjectId() {
            int id = await _db.Projects.OrderByDescending(p => p.CategoryProject).Select(p => p.CategoryProject).FirstOrDefaultAsync();
            id++;

            return id;
        }

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

        /// <summary>
        /// Метод получает список проектов вместе с фото каждого проекта.
        /// </summary>
        public async override Task<IList> GetAllProjectsWithUrl() {
            try {
                //var aProjects = await _db.Projects.Join(_db.DetailProjects,
                //    t1 => t1.ProjectId,
                //    t2 => t2.ProjectId,
                //    (t1, t2) => new {
                //        id = t1.ProjectId,
                //        projectName = t1.ProjectName,
                //        url = t2.Url
                //    }).ToListAsync();

                var aProjects = await _db.Projects.Select(p => new {
                    id = p.ProjectId,
                    projectName = p.ProjectName,
                    projectDetail = p.ProjectDetail,
                    url = new string[] { p.Url },
                    category = p.CategoryProject
                }).ToListAsync();

                return aProjects;
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}