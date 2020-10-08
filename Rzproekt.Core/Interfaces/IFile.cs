using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core.Interfaces {
    public interface IFile {
        Task<string> Upload(IFormCollection form);
    }
}
