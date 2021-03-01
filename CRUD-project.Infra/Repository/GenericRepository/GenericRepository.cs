﻿using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using CRUD_project.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_project.Infra.Repository.GenericRepository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
        
    {
        private readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Query().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await Query().FirstOrDefaultAsync(q => q.Id == id);
            if(entity != null)
            {
                DbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected IQueryable<TEntity> Query() => DbSet.AsNoTracking();
    }
}
