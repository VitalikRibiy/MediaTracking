using System.Collections.Generic;
using System.Threading.Tasks;
using MediaTracking.BLL.DTOs.Abstraction;

namespace MediaTracking.BLL.Services.IServices
{
    public interface ICrudService<TEntityDTO> where TEntityDTO: IDTOEntity
    {
        Task<TEntityDTO> GetAsync(int id);
        Task<IEnumerable<TEntityDTO>> GetRangeAsync(uint offset, uint amount);
        Task<TEntityDTO> CreateAsync(TEntityDTO dto);
        Task<TEntityDTO> UpdateAsync(TEntityDTO dto);
        Task DeleteAsync(int id);
    }
}