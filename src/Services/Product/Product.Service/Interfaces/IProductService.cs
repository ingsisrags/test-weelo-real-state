using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Service.Interfaces
{
    public interface IProductService
    {
        Task<PropertyOutput> CreatePropertyBuilding(CreatePropertyInput input);
        Task<List<PropertyOutput>> GetProperties(FilterPropertyInput input);
    }
}
