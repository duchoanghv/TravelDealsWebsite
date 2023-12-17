using System.Text;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;

namespace TravelDealsWebsite.Utility
{
    public static class FileExtensions
    {
        public static string UploadFile(this IFormFile file, string webRootPath, string topicFolder)
        {
            var uniqueFileName = StringExtension.GetUniqueFileName(file.FileName);
            var uploadPath = Path.Combine($"/assets/images/{topicFolder}/", uniqueFileName);
            file.CopyTo(new FileStream(webRootPath + uploadPath, FileMode.Create));
            return uploadPath;
        }
        public static void RemoveFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}