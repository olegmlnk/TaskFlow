using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskFlow.Core;
using TaskFlow.Core.Models;

namespace TaskFlow.DataAccess
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(JwtOptions jwtOptions)
        {
            _options = jwtOptions;
        }

        public string GenerateToken(User user, IList<string> roles)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException("UserName cannot be null or empty.", nameof(user.UserName));

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(user.Email));

            if (roles == null || roles.Count == 0)
                throw new ArgumentException("Roles cannot be null or empty.", nameof(roles));

            if (string.IsNullOrWhiteSpace(_options.SecretKey))
                throw new InvalidOperationException("JWT SecretKey is not configured.");

            if (string.IsNullOrWhiteSpace(_options.Issuer))
                throw new InvalidOperationException("JWT Issuer is not configured.");

            if (string.IsNullOrWhiteSpace(_options.Audience))
                throw new InvalidOperationException("JWT Audience is not configured.");

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email)
    };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var keyBytes = Encoding.UTF8.GetBytes(_options.SecretKey);
            if (keyBytes.Length < 32)
                throw new InvalidOperationException("JWT SecretKey must be at least 256 bits (32 bytes) for HMAC-SHA256.");

            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
