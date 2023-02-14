using CVGeneratorApp.Api.StorageServices.Abstractions.Base;

namespace CVGeneratorApp.Api.StorageServices.Abstractions
{
    public interface ILocalStorage:IStorage
    {
        public string BaseUrl { get; }
    }
}
