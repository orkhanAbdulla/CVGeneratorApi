namespace CVGeneratorApp.Api.StorageServices.Concrete.Base
{
    public class Storage
    {
        public string FileRename(string FileName)
        {
            return Guid.NewGuid().ToString() + FileName;
        }
        public bool IsValidSize(long fileSize, int maxKb)
        {
            return fileSize / 1024 <= maxKb;
        }
    }
}
