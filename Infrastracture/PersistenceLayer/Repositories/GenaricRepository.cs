using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class GenaricRepository<TEntity, TKey>(StoreDbContext _dbContext) : IGenaricRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async  Task addAsync(TEntity entity) =>  await  _dbContext.Set<TEntity>().AddAsync(entity);
        

        public void Remove(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await  _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync( id);
        

        public void Update(TEntity entity) => _dbContext.Update(entity);
    }
}         //  UnitOfWork    ف الاحسن اشتغل علي ال  Repository  هنا علشان ممكن يكون في اكتر من   SaveChanges   ومش هنعمل 
