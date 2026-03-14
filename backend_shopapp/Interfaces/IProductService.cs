using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Product;

namespace backend_shopapp.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAll(ProductQueryParameters param);
        Task<ProductResponse?> GetById(string id);
        Task<string> Create(CreateProductRequest request);
        Task Update(string id, UpdateProductRequest request);
        Task Delete(string id);
    }
}
