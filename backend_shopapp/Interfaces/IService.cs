using backend_shopapp.Dtos;

namespace backend_shopapp.Interfaces
{
    public interface IService<TCreateDto, TUpdateDto, TDto>
    {
        Task<List<TDto>> GetAll(QueryParameters param);
        Task<TDto?> GetById(string id);
        Task Create(TCreateDto request);
        Task Update(string id, TUpdateDto request);
        Task Delete(string id);
    }
}
