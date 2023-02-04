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

        public void DeleteAsync(string pathOrContainerName, string fileName)
            => _storage.DeleteAsync(pathOrContainerName, fileName);

        public string FileRename(string FileName)
            =>_storage.FileRename(FileName);

        public bool IsValidSize(long fileSize, int maxKb)
            =>IsValidSize(fileSize, maxKb);

        public Task<(string path, string fileName)> UploadAsync(string pathOrContainerName, IFormFile file)
            =>UploadAsync(pathOrContainerName, file);
    }
}
