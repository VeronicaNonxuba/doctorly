using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace doctorly.scheduling.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    public AuthController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] Credential credential)
    {
        try
        {   //get user information
            var user = await _userService.GetUserAsync(credential);

            if (IsValidCredential(credential))
            {
                //Creating the Security COntext
                var claims = new List<Claim>{
                //TODO: consider getting the claims from DB later
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Email,user.Email)
                };

                var expiresAt = DateTime.UtcNow.AddMinutes(10);

                return Ok(new
                {
                    access_token = GenerateToken(claims, expiresAt),
                    expires_at = expiresAt
                });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        ModelState.AddModelError("UnAuthorised", "You are not authorised to access endpoint.");
        return Unauthorized(ModelState);
    }

    private bool IsValidCredential(Credential credential)
    {
        if (credential.Username == credential.Username
                    && credential.Password == credential.Password)
        {
            return true;
        }
        return false;
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

