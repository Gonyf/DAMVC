using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAMVC.Data;
using DAMVC.DTO;
using DAMVC.Models;
using DAMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAMVC.Controllers
{
    [Route("[controller]")]
    //[ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDto)
        {
            // validate request
            if (!ModelState.IsValid)
                return View();

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
            {
                ModelState.AddModelError("UserName", "User name is already taken");
                return View();
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            await _repo.Register(userToCreate, userForRegisterDto.Password);

            return View("Login");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDto)
        {
            if (!ModelState.IsValid)
            {
                //AddErrorsFromModel(ModelState.Values);
                return View();
            }
            userForLoginDto.Username = userForLoginDto.Username.ToLower();

            var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenHandler.WriteToken(token);

            var client = new HttpClient();
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenHandler.WriteToken(token));

            return Ok();
        }
        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            foreach (var error in values.SelectMany(modelState => modelState.Errors))
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage.ToString());
            }
        }

        private void AddError(string errorMessage)
        {
            ModelState.AddModelError("UserName", errorMessage);
        }
    }
}
