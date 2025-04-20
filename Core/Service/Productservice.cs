using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Productservice(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandAsync()
        {
            var Repo = _unitOfWork.GetRepository<ProductBrand, int>();
             var Brands= await  Repo.GetAllAsync();
             var BrandDto = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
            return BrandDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var Product = await _unitOfWork.GetRepository<Product , int>().GetAllAsync();
            var ProductDro = _mapper.Map<IEnumerable<Product> , IEnumerable<ProductDto>> (Product);
            return ProductDro;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypeAsync()
        {
            var Types =await _unitOfWork.GetRepository<ProductType , int>().GetAllAsync();
            var ProductTypeDto = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return ProductTypeDto;

        }

        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            var Product = await  _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Id);
              return _mapper.Map<Product, ProductDto>(Product);
        }
    }
}
