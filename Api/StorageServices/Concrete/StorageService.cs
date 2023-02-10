using CVGeneratorApp.Api.Common.Enums;
using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Abstractions.Base;

namespace CVGeneratorApp.Api.StorageServices.Concrete
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public void Delete(string pathOrContainerName, string fileName)
            => _storage.Delete(pathOrContainerName, fileName);

        public string FileRename(string FileName)
            =>_storage.FileRename(FileName);

        public bool CheckFileType(IFormFile file)
            => _storage.CheckFileType(file);

        public bool IsValidSize(long fileSize, int maxKb)
            => _storage.IsValidSize(fileSize, maxKb);

        public Task<(string path, string fileName)> UploadAsync(string pathOrContainerName,IFormFile file)
            => _storage.UploadAsync(pathOrContainerName,file);
    }
}
