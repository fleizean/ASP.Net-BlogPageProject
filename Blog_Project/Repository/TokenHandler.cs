using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace Blog_Project.Repository
{
	public class TokenHandler
	{
        public TokenHandler()
        {

        }

        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(token))
            {
                throw new ArgumentException("Invalid token");
            }

            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Check if the token is expired

            return DateTime.UtcNow < jwtToken.ValidTo;
        }
    }
}

