using JWT_TOKEN.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT_TOKEN.Controller
{
    [Authorize] // This makes all actions in this controller require authorization
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EComDbContext _context;
        public UserController(EComDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllUser")]
        public async Task <IActionResult> GetAllUser()
        { 
            var result = await _context.Set<User>().ToListAsync();
            if(result == null)
            {
                return NotFound("User List Is empty");
            }
            return Ok(result);

        }
    }
}
