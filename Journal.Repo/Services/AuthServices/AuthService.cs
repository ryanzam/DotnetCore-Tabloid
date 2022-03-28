using CryptoHelper;
using Journal.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Journal.Repository.Services.AuthServices
{
    public class AuthService
    {
        int _jwtLifeSpan;
        string _jwtSecret;

        public AuthService(int jwtLifeSpan, string jwtSecret)
        {
            _jwtLifeSpan = jwtLifeSpan;
            _jwtSecret = jwtSecret;
        }

        public AuthData GetAuthData(string id)
        {
            var expTime = DateTime.UtcNow.AddSeconds(_jwtLifeSpan);

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = expTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDes));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expTime).ToUnixTimeSeconds(),
                Id = id
            };
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}
