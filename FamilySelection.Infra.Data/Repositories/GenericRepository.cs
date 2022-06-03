using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Context;
using FamilySelection.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Infra.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly FamilySelectionDataContext _dataContext;
        public GenericRepository(FamilySelectionDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public FamilySelectionDataContext GetDataContext()
        {
            return _dataContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dataContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
