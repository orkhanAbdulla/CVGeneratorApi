using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Abstractions.Base;
using CVGeneratorApp.Api.StorageServices.Concrete.Base;
using System.IO;

namespace CVGeneratorApp.Api.StorageServices.Concrete
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void DeleteAsync(string pathOrContainerName, string fileName)
        {
            string DeleteFile = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName, fileName);
            if (File.Exists(DeleteFile))
            {
                File.Delete(DeleteFile);
            }
        }

        public async Task<(string path, string fileName)> UploadAsync(string pathOrContainerName, IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            string fileNewName = FileRename(file.FileName);
            string rooting = Path.Combine(uploadPath, fileNewName);
            using (FileStream stream = new FileStream(rooting, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }
            return (rooting, fileNewName); 
        }
    }
}
