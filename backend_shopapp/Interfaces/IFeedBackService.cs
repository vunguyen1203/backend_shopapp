using backend_shopapp.Dtos;
using backend_shopapp.Dtos.FeedBack;

namespace backend_shopapp.Interfaces
{
    public interface IFeedBackService
    {
        Task FeedBack(string userId, string productId, CreateFeedBackRequest request);
        Task ReplayFeedBack(string userId, string parentId, ReplayFeedBackRequest request);
        Task<List<FeedBackResponse>> GetAll(string productId, QueryParameters param);
    }
}
