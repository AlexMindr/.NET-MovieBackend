using ProiectDAW.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        // Get all data
        Task<List<TEntity>> GetAll();
        
        // Create
        Task CreateAsync(TEntity entity);
        
        // Update
        void Update(TEntity entity);
        
        // Delete
        void Delete(TEntity entity);
        
        // Find
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
