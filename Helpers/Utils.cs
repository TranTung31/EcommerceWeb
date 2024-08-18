using System.Text;

namespace EcommerceWeb.Helpers
{
    public class Utils
    {
        public static string UploadImage(IFormFile HinhAnh, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, HinhAnh.FileName);
                using (var file = new FileStream(fullPath, FileMode.CreateNew))
                {
                    HinhAnh.CopyTo(file);
                }
                return HinhAnh.FileName;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        public static string GenerateRandomKey(int length = 5)
        {
            var pattern = @"qazwsxedcrfvtgbyhnujmikolpQAZWSXEDCRFVTGBYHNUJMIKOLP!";
            var sb = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[random.Next(0, pattern.Length)]);
            }
            return sb.ToString();
        }
    }
}
