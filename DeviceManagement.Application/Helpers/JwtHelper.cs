using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Application.Helpers
{
    public class JwtHelper
    {
        public static JwtSecurityToken GetJwtToken(string username, string signingKey, TimeSpan expiration, Claim[] additionalClaims = null)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
            };

            if (additionalClaims != null)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(additionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            return new JwtSecurityToken(expires: DateTime.UtcNow.Add(expiration), claims: claims, signingCredentials: creds);
        }
    }
}
