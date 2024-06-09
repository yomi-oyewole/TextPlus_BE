using System.Runtime.InteropServices;
using TextPlus_BE.Model;
using TextPlus_BE.Setting;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims; // Add this line

namespace TextPlus_BE.Helper.Security
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(UserModel user, [Optional] DateTime? expiration);
        string ValidateToken(string token);
    }
    public class JwtProvider : IJwtProvider
    {

        private readonly IJwtSettings _appSettings;
        private readonly DateTime defaultExpiration = DateTime.UtcNow.AddHours(24.0);

        public JwtProvider(IJwtSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string GenerateJwtToken(UserModel user, [Optional] DateTime? expiration)
        {
            if (expiration == null)
            {
                expiration = defaultExpiration;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("email", user.Email),
                    new Claim("number", user.Number.ToString()),
                    new Claim("number", user.CreatedAt.ToString(), ClaimValueTypes.Integer64),
                }),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }


        public string ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken ValidateToken);

                var jwtToken = (JwtSecurityToken)ValidateToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                //check for other claims
                // return account id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

    }
}


