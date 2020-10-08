using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Rzproekt.Models {
    public class FileManager {
        public async Task<bool> UploadFile(IFormFile file) {
            try {
                bool isCopied = false;
                if (file.Length > 0) {
                    string fileName = file.FileName;
                    string extension = Path.GetExtension(fileName);

                    // Задает расширение файлов.
                    if (extension == ".png" || extension == ".jpg" || extension == ".mp4") {
                        // Записывает путь к папке, в которую будет загружать файлы.
                        string filePath = Path.GetFullPath(
                            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img"));
                        using (var fileStream = new FileStream(
                            Path.Combine(filePath, fileName),
                                           FileMode.Create)) {
                            await file.CopyToAsync(fileStream);
                            isCopied = true;
                        }
                    }
                    else {
                        throw new Exception();
                    }
                }
                return isCopied;
            }

            catch (Exception ex) {
                throw new Exception("Файл должен быть формата .png или .jpg", ex);
            }
        }
    }
}
