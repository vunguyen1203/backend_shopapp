using backend_shopapp.Interfaces;

namespace backend_shopapp.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly long _maxFileSize = 15 * 1024 * 1024;
        private readonly string[] _allowedExtensions =
        { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg" };


        public ImageService(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetWebRootPath()
        {
            return _environment.WebRootPath
            ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        private void ValidateImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");


            if (file.Length > _maxFileSize)
                throw new ArgumentException("The file exceeds the allowed size (15MB).)");


            var extension = Path.GetExtension(file.FileName).ToLower();


            if (!_allowedExtensions.Contains(extension))
                throw new ArgumentException("Image format not supported");
        }

        public async Task<string> UploadImage(IFormFile file, string folderName)
        {
            ValidateImage(file);

            var fileName = Path.GetFileName(file.FileName).ToLower();
            var folderPath = Path.Combine(GetWebRootPath(), "images", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";


            return $"{baseUrl}/images/{folderName}/{fileName}";
        }

        public async Task<string> UpdateImage(IFormFile newFile, string oldImagePath, string folderName)
        {
            var newImagePath = await UploadImage(newFile, folderName);

            if (!string.IsNullOrWhiteSpace(oldImagePath))
            {
                await DeleteImage(oldImagePath);
            }

            return newImagePath;
        }

        public Task<bool> DeleteImage(string imagePath)
        {
            if (imagePath == null) return Task.FromResult(false);

            var uri = new Uri(imagePath);
            var relativePath = uri.LocalPath.TrimStart('/');

            var fullPath = Path.Combine(GetWebRootPath(),relativePath
                .Replace("/", Path.DirectorySeparatorChar.ToString()));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
