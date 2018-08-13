using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EventsManager.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventsManager.Identity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private RoleManager<Role> _roleManager;

        public TokenController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: api/values
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string grant_type)
        {
            var user = await _userManager.FindByEmailAsync(username);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.GivenName, "Nitya Prakash Sharma")
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6febd7b1-cc03-4af2-bf9e-fba1aa81a18b"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(issuer: "http://nimrodcomputing.co.uk",
                        claims: claims,
                        expires: DateTime.Now.AddDays(15),
                        signingCredentials: creds);

                    return Ok(new
                    {
                        access_token = new JwtSecurityTokenHandler().WriteToken(token),
                        expires_on = DateTime.Now.AddDays(15)
                    });
                }
            }


            return BadRequest("Could not create token");
        }

#if DEBUG
        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            var roles = new[] {"Admin"};
            foreach (var role in roles)
            {
                if (await _roleManager.FindByNameAsync(role) == null)
                {
                    await _roleManager.CreateAsync(new Role
                    {
                        Name = role
                    });
                }
            }

            foreach (var user in _userManager.Users.ToList())
            {
                await _userManager.DeleteAsync(user);
            }

            var users = new[]
            {
                "admin@huntermail.org",
                "william@huntermail.org"
            };

            foreach (string userName in users)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    await _userManager.CreateAsync(new User
                    {
                        UserName = userName,
                        Email = userName,
                        Forename = userName.Substring(0,1).ToUpper() + userName.Split("@")[0].Substring(1),
                        Surname = userName.StartsWith("admin") ? "Admin" : "Hunter"
                    }, "P@ssword1");
                }
                else
                {
                    user.Forename = userName.Substring(0, 1).ToUpper() + userName.Split("@")[0].Substring(1);
                    user.Surname = userName.StartsWith("admin") ? "Admin" : "Hunter";
                    await _userManager.UpdateAsync(user);
                }
            }

            return NoContent();
        }
#endif

    }
}