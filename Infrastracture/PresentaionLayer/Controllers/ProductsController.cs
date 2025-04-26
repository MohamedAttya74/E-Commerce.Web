using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentaionLayer.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // BaseUrl/api/Products 
    public class ProductsController(IServiceManger _serviceManger) : ControllerBase
    {
        //Get All Products
        //Get BaseUrl/api/Products 
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
             var Products = await _serviceManger.ProductService.GetAllProductAsync();
            return Ok(Products);
        }
        // Get Product By id 
        //Get BaseUrl/api/Products/10
        [HttpGet("{id:int}")]
        public async Task<ActionResult <IEnumerable<ProductDto>>> GetProduct(int id)
        {
            var Product = await _serviceManger.ProductService.GetProductByIdAsync(id);
            return Ok(Product);
        }
        // Get All Types 
        //Get BaseUrl/api/Products/types 
        [HttpGet("types")]
        public async Task<ActionResult<TypeDto>> GetAllTypes() 
        {
            var Types =await _serviceManger.ProductService.GetAllTypeAsync();
            return Ok(Types);
        }
        //Get All Brands 
        //Get BaseUrl/api/Products/brands 
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var Brands =  await _serviceManger.ProductService.GetAllBrandAsync();
            return Ok(Brands);
        }

    }
}
