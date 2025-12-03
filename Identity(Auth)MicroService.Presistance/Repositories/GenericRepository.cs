using Identity_Auth_MicroService.Domain.Contracts;
using Identity_Auth_MicroService.Presistance.Data.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Auth_MicroService.Presistance.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IdentityUser
    {
        private readonly ClinicIdentityDbContext _dbContext;

        public GenericRepository(ClinicIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public void Remove(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
    }
}
