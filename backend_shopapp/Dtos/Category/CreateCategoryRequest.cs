using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
