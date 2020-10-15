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
        public async override Task AddProjectInfo(IFormCollection filesMain, IFormCollection filesProject, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                ProjectDto projectDto = new ProjectDto();
                JObject jsonObj = JObject.Parse(jsonString);
                string nameProject = jsonObj["nameProject"].ToString();
                string detailProject = jsonObj["detailProject"].ToString();
                //string mainTitle = jsonObj["mainTitle"].ToString();

                if (filesMain.Files.Count > 0) {
                    string path = await common.UploadSingleFile(filesMain);
                    path = path.Replace("wwwroot", "");
                    projectDto.Url = path;
                }

                //if (mainTitle != null) {
                //    projectDto.MainTitle = mainTitle;
                //}

                projectDto.Block = BlockType.PROJECT;
                projectDto.Title = nameProject;
                projectDto.Detail = detailProject;
                projectDto.IsMain = "false";
                projectDto.IsMainImage = "true";
                await _db.Projects.AddAsync(projectDto);
                await _db.SaveChangesAsync();
                Debugger.Break();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
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
    }
}