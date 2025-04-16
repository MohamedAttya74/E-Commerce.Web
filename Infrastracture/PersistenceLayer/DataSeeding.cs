using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    internal class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            var PindingMigration = await _dbContext.Database.GetPendingMigrationsAsync(); 
            if (PindingMigration .Any())
            {
                await _dbContext.Database.MigrateAsync();      // Creat  بتاتعتها لسه متعملهاش  Database ل حاجه ال  Insert  علشان نضمن ان مش هنعمل 
            }

            try
            {
                if (!_dbContext.Set<ProductBrand>().Any())
                {
                    //var ProductBrandData = await File.ReadAllTextAsync(@"..\Infrastracture\PersistenceLayer\Data\DataSeed\brands.json");
                    var ProductBrandData =  File.OpenRead(@"..\Infrastracture\PersistenceLayer\Data\DataSeed\brands.json");
                    // Convert Data "String"  => C# Objects [Productbrand]
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrands != null && ProductBrands.Any())
                    {
                      await  _dbContext.ProdcutBrands.AddRangeAsync(ProductBrands);

                    }
                }
                if (!_dbContext.Set<ProductType>().Any())
                {
                    var ProductTypeData = File.OpenRead(@"..\Infrastracture\PersistenceLayer\Data\DataSeed\types.json");
                    // Convert Data "String"  => C# Objects [Productbrand]
                    var ProductTypes =await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    if (ProductTypes != null && ProductTypes.Any())
                    {
                       await  _dbContext.productTypes.AddRangeAsync(ProductTypes);
                    }
                }
                if (!_dbContext.Set<Product>().Any())
                {
                    var ProductData =  File.OpenRead(@"..\Infrastracture\PersistenceLayer\Data\DataSeed\products.json");
                    // Convert Data "String"  => C# Objects [Productbrand]
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Products != null && Products.Any())
                    {
                       await _dbContext.Prodcuts.AddRangeAsync(Products);

                    }
                }

                await  _dbContext.SaveChangesAsync();             // ودي اهم حاجه فيهم انك تعملها ومتنساهاش 
            }
            catch (Exception ex)
            {
                // TODO 
            }
             
        }
    }
}
