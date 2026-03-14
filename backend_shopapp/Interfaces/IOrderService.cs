using backend_shopapp.Dtos.Order;
using backend_shopapp.Dtos;

namespace backend_shopapp.Interfaces
{
    public interface IOrderService
    {
        Task<string> Create(string userId, CreateOrderRequest request);
        Task<List<OrderResponse>> GetAll(OrderQueryParameters param, string userId);
        Task<OrderResponse> GetById(string id);
        Task UpdateInfo(string id, UpdateOrderRequest request);
        Task CancellOrder(string id);
        Task SetShipping(string orderCode);
        Task ConfirmOrderSuccess(string orderId);
    }
}

