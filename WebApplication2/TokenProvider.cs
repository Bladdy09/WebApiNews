using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2
{
    public class TokenProvider : ITokenProvider
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretkey;
        private string _algorit { get; set; }

        private readonly SymmetricSecurityKey _signingkey;

        public TokenProvider(string issuer, string audience, string secretkey)
        {
            _issuer = issuer;
            _audience = audience;
            _secretkey = secretkey;
            _algorit = SecurityAlgorithms.HmacSha256Signature;
            _signingkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretkey));
        }
        public string CreateToken(Usuario usuario, DateTime expiretionDate)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.NombreUsuario));
            claims.Add(new Claim(ClaimTypes.Name, usuario.Contrasena));

            ClaimsIdentity identity = new ClaimsIdentity(claims);
            SecurityToken securityToken = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_signingkey, _algorit),
                Expires = expiretionDate.ToUniversalTime(),
                Subject = identity,
            });
            return tokenHandler.WriteToken(securityToken);

        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _signingkey,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)

            };
        }

    }
}
