using System.Text;

namespace YigitAkuEmployee.MVC.Extensions
{
    public static class FormFileExtension
    {
        public static async Task<string> FileToStringAsync(this IFormFile formFile)
        {
            using MemoryStream memoryStream = new();
            await formFile.CopyToAsync(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
        public static async Task<string> DocumentFileToStringAsync(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}
