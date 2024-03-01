using Project.Domain.Entities.DTOs;
using Project.Domain.Entities.Models;
using System.Linq.Expressions;

namespace Project.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> Create(User user);
        public Task<User> GetByAny(Expression<Func<User, bool>> expression);
        public Task<IEnumerable<User>> GetAll();
        public Task<bool> Delete(Expression<Func<User, bool>> expression);
        public Task<User> Update(int Id, UserDTO userDTO);
    }
}
