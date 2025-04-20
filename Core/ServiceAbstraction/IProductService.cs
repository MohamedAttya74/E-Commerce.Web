using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {

        // Get All Products 
        Task<IEnumerable<ProductDto>> GetAllProductAsync();

        // Get ById
        Task<ProductDto> GetProductByIdAsync( int Id);
        // Get All Types 
        Task<IEnumerable<TypeDto>> GetAllTypeAsync();

        // Get All Brand  
        Task<IEnumerable<BrandDto>> GetAllBrandAsync();

    }
}
