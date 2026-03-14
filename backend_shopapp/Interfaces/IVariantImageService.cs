namespace backend_shopapp.Interfaces
{
    public interface IVariantImageService
    {
        Task UploadImages(string variantId, List<IFormFile> files);
        Task UpDateImages(string variantId, List<IFormFile> files);
        Task DeleteImages(string variantId);
    }
}
