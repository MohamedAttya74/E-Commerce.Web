using DomainLayer.Contracts;
using DomainLayer.Models;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string , object> _reositories = [];
        public IGenaricRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            // Get Name 
            var TypeName = typeof(TEntity).Name;
            // Dic<string , Object > ==> String Key [Name Of Type ] --- Object [Object From Genaric Repository]
            //if (_reositories.ContainsKey(TypeName))
            //    return (IGenaricRepository<TEntity, Tkey>) _reositories[TypeName]  ;

            if (_reositories.TryGetValue(TypeName , out object?  value))
                return (IGenaricRepository<TEntity, Tkey>)value;
            else
            {
                // Create Object 
                var Repo =  new GenaricRepository<TEntity , Tkey>(_dbContext);
                // Store Object In Dic 
                _reositories["TypeName"]= Repo ;          //_reositories.Add(TypeName, Repo);
                // Return Object 
                return Repo ;
            }
        }

        public async Task<int> SaveShangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
