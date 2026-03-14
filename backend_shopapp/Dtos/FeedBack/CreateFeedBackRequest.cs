using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.FeedBack
{
    public class CreateFeedBackRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
