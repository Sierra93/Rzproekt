using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}
