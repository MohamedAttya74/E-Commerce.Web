using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product , ProductDto>()
                .ForMember(dis => dis.BrandName , Options => Options.MapFrom(Src => Src.ProductBrand.Name))
                .ForMember(dis => dis.TypeName , Options => Options.MapFrom(Src => Src.productType.Name));
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType , TypeDto>();
        }
    }
}
