﻿using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions;
using Project.Infrastructure.Persistance;
using System.Linq.Expressions;

namespace Project.Infrastructure.Repositories
{

    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly ProjectDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepo(ProjectDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            if (result == null)
            {
                return false;
            }
            _dbSet.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(expression);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var result = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}

