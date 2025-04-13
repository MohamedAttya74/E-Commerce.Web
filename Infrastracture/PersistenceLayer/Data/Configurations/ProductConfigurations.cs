using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.ProductBrand)  //  Product من ناحيه ال 
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(P => P.productType) 
                .WithMany()
                .HasForeignKey(p => p.TypeId);

            builder.Property(P => P.Price)
                .HasColumnType("decimal(10,2)");

        }
    }


}
