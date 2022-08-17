using Microsoft.AspNetCore.Http;
using MEGZ_Web_Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MEGZ_Web_Api.Models;
using System.Security.Claims;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace MEGZ_Web_Api.Controllers
{
    
    
    [Route("MeGz/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        DBContext dBContext;
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        IConfiguration configuration;

        public AccountController(DBContext dBContext,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration)
        {
            this.dBContext = dBContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        [HttpGet("{email}",Name ="getByEmail")]
        [Authorize]
        public async Task<IActionResult> GetByEmail(string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("invalid email");
            else
            {
                UserData userData = new UserData();
                userData.Id = user.Id;
                userData.Name = user.UserName;
                userData.Email = user.Email;
                userData.Phone = user.PhoneNumber;
                return Ok(userData);
            }
        }
        [HttpPost]
        [Route("/MeGz/[controller]/Login")]
        public async Task<IActionResult> Login(LoginViewModel userData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(userData.email);
                if (user == null)
                {
                    return Unauthorized("Invalid email address");
                }
                else if (await userManager.CheckPasswordAsync(user, userData.password))
                {
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.Name,user.UserName));
                    userClaims.Add(new Claim("email address",user.Email));
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id));
                    userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var roles =await userManager.GetRolesAsync(user);
                    foreach(var role in roles)
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role,role));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    var myToken = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(14),
                        claims: userClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
                        return Ok(
                        new {token = new JwtSecurityTokenHandler().WriteToken(myToken),
                        expiration = myToken.ValidTo});
                }
                else
                    return Unauthorized("Invalid Password");
            }
            return Unauthorized(ModelState);
 
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Register(RegisterViewModel userData)
            {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(userData.Email);
                if (user != null)
                {
                    return BadRequest("This email already taken");
                }
                else
                {
                    ApplicationUser appUser = dBContext.Users.FirstOrDefault(n => n.PhoneNumber == userData.PhoneNumber);
                    if (appUser != null)
                    {
                        return BadRequest("This phone number is used");
                    }
                }
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Name = userData.Name;
                applicationUser.UserName = userData.Email;
                applicationUser.Email = userData.Email;
                applicationUser.PhoneNumber = userData.PhoneNumber;
                IdentityResult identityResult = await userManager.CreateAsync(applicationUser,userData.Password);
                if (!identityResult.Succeeded)
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("ModelErrors", error.Description);
                    }
                    return BadRequest(ModelState);
                }
                string? url = Url.Link("getByEmail", new { email = applicationUser.Email });
                return Created(url, userData);
            }
            else
                return BadRequest(ModelState);
        }
    }
}
