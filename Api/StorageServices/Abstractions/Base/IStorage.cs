namespace CVGeneratorApp.Api.StorageServices.Abstractions.Base
{
    public interface IStorage
    {
        public Task<(string path, string fileName)> UploadAsync(string pathOrContainerName, IFormFile file);
        void DeleteAsync(string pathOrContainerName, string fileName);
        public string FileRename(string FileName);
        public bool IsValidSize(long fileSize, int maxKb);
    }
}
