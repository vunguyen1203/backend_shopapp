namespace backend_shopapp.Interfaces
{
    public interface IImageService
    {
        public Task<string> UploadImage(IFormFile file, string folderName);
        public Task<string> UpdateImage(IFormFile newFile, string oldImagePath, string folderName);
        public Task<bool> DeleteImage(string imagePath);
    }
}
