
using Microsoft.AspNetCore.Http;

namespace LibraryManagementSystem.Service.Util
{
    public class ImageHelper
    {
        public static async Task<string> AddImageAsync(IFormFile imageFile)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var filePath = Path.Combine("wwwroot/img", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return fileName;
        }

        public static void DeleteOldImage(string fileName)
        {

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            string filePath = Path.Combine(imagePath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
