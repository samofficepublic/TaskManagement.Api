using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Utils;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Models;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Services.ContractService
{
    public class JwtService : IJwtRpository
    {
        private readonly SiteSettings _siteSetting;

        public JwtService(IOptionsSnapshot<SiteSettings> siteSetting)
        {
            _siteSetting = siteSetting.Value;
        }

        public async Task<AccessToken> GenerateTokenAsync(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.jwtSettings.SecretKey); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.jwtSettings.Encryptkey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await _getClaimsAsync(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.jwtSettings.Issuer,
                Audience = _siteSetting.jwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSetting.jwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSetting.jwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            //JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            //string encryptedJwt = tokenHandler.WriteToken(securityToken);

            return new AccessToken(securityToken);
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(User user)
        {
            var list = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.MobileNumber),
                new Claim(ClaimTypes.Email,user.Email)
            };

            return list;
        }
    }
}
