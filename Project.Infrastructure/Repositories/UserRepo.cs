using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions;
using Project.Domain.Entities.Models;
using Project.Infrastructure.Persistance;

namespace Project.Infrastructure.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(ProjectDbContext context, DbSet<User> dbset) : base(context, dbset)
        {

        }

    }
}
