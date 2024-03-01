using System.Linq.Expressions;

namespace Project.Application.Abstractions
{
    public interface IBaseRepo<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<T> GetByAny(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAll();
        public Task<bool> Delete(Expression<Func<T, bool>> expression);
        public Task<T> Update(T entity);
    }
}
