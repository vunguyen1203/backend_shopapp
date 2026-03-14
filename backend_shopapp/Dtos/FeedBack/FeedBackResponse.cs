namespace backend_shopapp.Dtos.FeedBack
{
    public class FeedBackResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ReplayFeedBackResponse> Replies { get; set; }
    }
}
