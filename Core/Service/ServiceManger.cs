using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManger(IUnitOfWork unitOfWork , IMapper mapper) : IServiceManger
    {

        private readonly Lazy<IProductService> _LazeproductService = new Lazy<IProductService>( () => new Productservice(unitOfWork , mapper ));
        public IProductService ProductService => _LazeproductService.Value;
    }
}
