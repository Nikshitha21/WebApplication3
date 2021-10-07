using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly UserDetailDbContext _context;
        private IConfiguration _config; 

        public UserDetailsController(UserDetailDbContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetailss()
        {
            return await _context.UserDetailss.ToListAsync();
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
        {
            var userDetails = await _context.UserDetailss.FindAsync(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return userDetails;
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetails(int id, UserDetails userDetails)
        {
            if (id != userDetails.customerID)
            {
                return BadRequest();
            }
          
            _context.Entry(userDetails).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDetails>> PostUserDetails(UserDetails userDetails)
            
        {
            var actNo = _context.UserDetailss.Max(a => a.AccountNumber);
            userDetails.AccountNumber = actNo+1;
           
            _context.UserDetailss.Add(userDetails);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetUserDetails", new { id = userDetails.customerID }, userDetails);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            var userDetails = await _context.UserDetailss.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            _context.UserDetailss.Remove(userDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginDetails login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {

                var tokenString = GenerateJSONWebToken(user);


                response = Ok(new { token = tokenString, user });
            }
            return response;
        }

      

        private string GenerateJSONWebToken(UserDetails userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DarkSecretInTheLight"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserDetails AuthenticateUser(LoginDetails login)
        {
            // UserInfo user = null;
            var validUser = _context.UserDetailss.FirstOrDefault(c => c.UserName == login.UserName && c.Password == login.Password);
            return validUser;
        }


        private bool UserDetailsExists(int id)
        {
            return _context.UserDetailss.Any(e => e.customerID == id);
        }
    }
}
