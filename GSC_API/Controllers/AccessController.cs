using GSC_API.DataAccess;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IJwtHandler jwtHandler;

        private readonly LoanDBContext loanDBContext;

        public AccessController(IJwtHandler jwtHandler, LoanDBContext DBContext)
        {
            this.jwtHandler = jwtHandler;
            loanDBContext = DBContext;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto user) 
        {

            if (string.IsNullOrWhiteSpace(user?.Password) || string.IsNullOrWhiteSpace(user?.UserName))
            {
                return BadRequest("The UserName or Password are Empty or Null");
            }

            var userlogin = loanDBContext
                            .Users
                            .Include(c => c.Rol)
                            .Where(b => b.Username == user.UserName)
                            .Where(a => a.Password == user.Password).SingleOrDefault();

            if (userlogin is null) {
                return BadRequest("The username or password may be wrong");
            }


            var rol = new List<string> { userlogin.Rol.RolDescription };

            var bearer = jwtHandler.GenerateToken(user, rol);
            return Ok(new
            {
                token = bearer,
            });


        }
    }
}

