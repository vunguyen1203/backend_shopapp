using backend_shopapp.Interfaces;
using backend_shopapp.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_shopapp.Services
{
    public class VariantImageService : IVariantImageService
    {
        private readonly AppDbContext _db;
        private readonly IImageService _imageService;

        public VariantImageService(AppDbContext db, IImageService imageService)
        {
            _db = db;
            _imageService = imageService;
        }

        public async Task UploadImages(string variantId, List<IFormFile> files)
        {
            var images = new List<VariantImage>();

            for (int i = 0; i < files.Count; i++)
            {
                var imageUrl = await _imageService.UploadImage(files[i], "product");

                images.Add(new VariantImage
                {
                    VariantId = variantId,
                    ImageUrl = imageUrl,
                    IsMain = i == 0
                });
            }

            _db.VariantImages.AddRange(images);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteImages(string variantId)
        {
            var images = await _db.VariantImages
                .Where(x => x.VariantId == variantId)
                .ToListAsync();

            foreach (var img in images)
            {
                await _imageService.DeleteImage(img.ImageUrl);
            }

            _db.VariantImages.RemoveRange(images);
            await _db.SaveChangesAsync();
        }

        public async Task UpDateImages(string variantId, List<IFormFile> files)
        {
            await DeleteImages(variantId);           
            await UploadImages(variantId, files);
        }
    }
}
