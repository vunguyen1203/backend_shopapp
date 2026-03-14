using System.ComponentModel.DataAnnotations;

namespace backend_shopapp.Dtos.FeedBack
{
    public class ReplayFeedBackRequest
    {
        [Required]
        public string Content { get; set; }
    }
}
