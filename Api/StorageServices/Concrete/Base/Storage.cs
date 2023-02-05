using CVGeneratorApp.Api.Common.Enums;
using Microsoft.VisualBasic.FileIO;

namespace CVGeneratorApp.Api.StorageServices.Concrete.Base
{
    public class Storage
    {
        public bool CheckFileType(IFormFile file)
        {
            if (file.ContentType.ToUpper().Contains(FileType.PDF.ToString().ToUpper())) return true;
            return false;
        }
        public string FileRename(string FileName)
        {
            Random r = new Random();
            return r.Next()+FileName;
        }
        public bool IsValidSize(long fileSize, int maxKb)
        {
            return fileSize / 1024 <= maxKb;
        }
    }
}
