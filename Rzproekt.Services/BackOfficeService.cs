using Microsoft.AspNetCore.Http;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы админки.
    /// </summary>
    public class BackOfficeService : BackOfficeBase {
        ApplicationDbContext _db;

        public BackOfficeService(ApplicationDbContext db) => _db = db;        
    }
}