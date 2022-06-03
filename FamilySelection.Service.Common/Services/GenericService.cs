using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Interfaces;
using FamilySelection.Service.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Service.Common.Services
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetRepository().GetAll();
        }

        public async Task Create(TEntity entity)
        {
            Consistency(entity);
            await GetRepository().Create(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task Update(int id, TEntity entity)
        {
            Consistency(entity);
            await GetRepository().Update(id, entity);
        }

        public async Task Delete(int id)
        {
            await GetRepository().Delete(id);
        }

        public IGenericRepository<TEntity> GetRepository()
        {
            return _genericRepository;
        }

        public abstract void Consistency(TEntity entity);
    }
}
