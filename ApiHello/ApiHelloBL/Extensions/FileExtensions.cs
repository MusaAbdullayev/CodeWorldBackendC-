using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiHelloBL.Extensions
{
    public static class FileExtensions
    {
        public static bool IsValidType(this IFormFile file, string type)
          => file.ContentType.StartsWith(type);
        public static bool IsValidSize(this IFormFile file, int kb)
            => file.Length <= kb * 1024;
        public static async Task<string> UploadAsync(this IFormFile file, params string[] paths)
        {
            string uploadPath = Path.Combine(paths);
            if (!Path.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            string newFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
            using (Stream stream = File.Create(Path.Combine(uploadPath, newFileName)))
            {
                await file.CopyToAsync(stream);
            }
            return newFileName;
        }

        public static void DeleteFile(string fileName, params string[] paths)
        {
            // Bazada "/uploads/products/image.jpg" kimi saxladığımız üçün başındakı "/" simvolunu təmizləyirik
            string relativePath = fileName.TrimStart('/');
            string fullPath = Path.Combine(Path.Combine(paths), relativePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
