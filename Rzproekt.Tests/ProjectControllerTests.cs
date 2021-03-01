using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rzproekt.Core.Data;

namespace Rzproekt.Tests
{
    [TestClass]
    public class ProjectControllerTests
    {
        ApplicationDbContext _db;

        public ProjectControllerTests(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Метод тестирует получение 3 тестов, а также ситуацию если получили например не 3 а 2 проекта.
        /// </summary>
        [TestMethod]
        public void GetProjects()
        {

        }
    }
}
