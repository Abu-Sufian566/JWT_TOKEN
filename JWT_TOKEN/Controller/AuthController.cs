using JWT_TOKEN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_TOKEN.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly EComDbContext _context;

        public AuthController(JwtService jwtService, EComDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
           
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Validate user credentials against the database
            var user = _context.Users.FirstOrDefault(u => u.UserName == model.Username && u.Password == model.Password);
            if (user != null)
            {
                var token = _jwtService.GenerateToken(user.Id.ToString(), user.UserName);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
        public class LoginModel
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }
    }
}
