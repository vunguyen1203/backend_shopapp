using backend_shopapp.Interfaces;
using Slugify;

namespace backend_shopapp.Services
{
    public class SlugifyService : ISlugifyService
    {
        private static readonly SlugHelper _slugHelper = new();
        public string GenerateSlugify(string name)
        {
            return _slugHelper.GenerateSlug(name.Replace("đ", "d").Replace("Đ", "D"));
        }
    }
}
