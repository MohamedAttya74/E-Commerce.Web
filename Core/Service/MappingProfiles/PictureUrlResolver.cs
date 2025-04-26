using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Service.MappingProfiles
{
    
    internal class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
           if (string.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;
            else
            {
                //var pictureUrl = $"https://localhost:7139/{source.PictureUrl}";
                var pictureUrl = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
                return pictureUrl;
            } 
               
        }
    }
}
