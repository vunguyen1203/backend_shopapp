using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Variant;

namespace backend_shopapp.Interfaces
{
    public interface IVariantService
    {
        Task Create(string productId, CreateVariantRequest request);
        Task<List<VariantReponse>> GetAll(string productId, QueryParameters param);
        Task Update(string id, UpdateVariantRequest request);
        Task Delete(string id);
    }
}
