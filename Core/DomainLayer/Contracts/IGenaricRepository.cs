using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public interface IGenaricRepository <TEntity , TKey>  where TEntity : BaseEntity<TKey>
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task <TEntity?> GetByIdAsync(TKey id);
        Task addAsync(TEntity entity);
        void Update(TEntity entity);    //   Task   علشان كدا مش   Async   علشان مفيش منهم حاجه بتشتغل 
        void Remove(TEntity entity);    //   Task   علشان كدا مش   Async   علشان مفيش منهم حاجه بتشتغل 

    }
}
