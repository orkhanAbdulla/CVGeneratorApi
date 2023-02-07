using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Concrete.Base;
using System.ComponentModel;

namespace CVGeneratorApp.Api.StorageServices.Concrete
{
    public class AzureStorage : Storage, IAzureStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _containerClient;
        readonly string AzureStorageUrl;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
            AzureStorageUrl = configuration["AzureStorageUrl"];
        }
        public void DeleteAsync(string pathOrContainerName, string fileName)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            if (_containerClient.GetBlobs().Any(b => b.Name == fileName))
            {
                BlobClient blobClient = _containerClient.GetBlobClient(fileName);
                blobClient.Delete();
            }
        }

        public async Task<(string path, string fileName)> UploadAsync(string pathOrContainerName, IFormFile file)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName.ToLower());
            await _containerClient.CreateIfNotExistsAsync();
            await _containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            string newFilename = FileRename(file.FileName);
            BlobClient blogClient = _containerClient.GetBlobClient(newFilename);
            await blogClient.UploadAsync(file.OpenReadStream());
            string rooting = AzureStorageUrl + pathOrContainerName.ToLower() + "/" + newFilename;
            return (rooting, newFilename);
        }
    }
}
