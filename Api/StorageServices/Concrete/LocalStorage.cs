using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Abstractions.Base;
using CVGeneratorApp.Api.StorageServices.Concrete.Base;


namespace CVGeneratorApp.Api.StorageServices.Concrete
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public string BaseUrl => $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}{_httpContextAccessor.HttpContext?.Request.PathBase}";

        public void Delete(string pathOrContainerName, string fileName)
        {
            string DeleteFile = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName, fileName);
            if (File.Exists(DeleteFile))
            {
                File.Delete(DeleteFile);
            }
        }
        public async Task<(string path, string fileName)> UploadAsync(string pathOrContainerName,IFormFile file)
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
            string fileAdress = Path.Combine(BaseUrl, pathOrContainerName, fileNewName);
            return (fileAdress, fileNewName); 
        }
    }
}
