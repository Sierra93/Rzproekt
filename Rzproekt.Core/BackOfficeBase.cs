using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает работу админки.
    /// </summary>
    public abstract class BackOfficeBase {
        public abstract Task AddLogoToHeader();
    }
}
