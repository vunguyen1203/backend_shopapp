using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Brand
{
    public class CreateBrandRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
    }
}
