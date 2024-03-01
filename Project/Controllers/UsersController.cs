using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstractions;
using Project.Domain.Entities.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _userRepo.GetAll();

            return Ok(result);
        }
    }
}
