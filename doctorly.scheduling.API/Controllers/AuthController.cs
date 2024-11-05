using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using doctorly.scheduling.Domain.Entities;


namespace doctorly.scheduling.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] Credential credential)
    {
        if (credential.Username == "admin"
            && credential.Password == "password")
        {
            //Creating the Security COntext
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name,"admin"),
                new Claim(ClaimTypes.Email,"admin@mywebsite.com")
            };

            var expiresAt = DateTime.UtcNow.AddMinutes(10);

            return Ok(new
            {
                access_token = GenerateToken(claims, expiresAt),
                expires_at = expiresAt
            });
        }
        ModelState.AddModelError("UnAuthorised", "You are not authorised to access endpoint.");
        return Unauthorized(ModelState);
    }
    private string GenerateToken(IEnumerable<Claim> claims, DateTime expiresAt)
    {
        var secretKey = Encoding.ASCII.GetBytes(
           _configuration.GetValue<string>("SecretKey") ?? string.Empty);

        //generate the jwt token
        var jwt = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAt,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}

