using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TodoList.JwtFeatures
{
    public class JwtHandler
    {
        public const string JwtSettingsSection = "JwtSettings";
        public const string SecurityKeySection = "securityKey";
        public const string validIssuerSection = "validIssuer";
        public const string validAudienceSection = "validAudience";

        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection(JwtSettingsSection);
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection(SecurityKeySection).Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public List<Claim> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };
            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection(validIssuerSection).Value,
                audience: _jwtSettings.GetSection(validAudienceSection).Value,
                claims: claims,
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}
