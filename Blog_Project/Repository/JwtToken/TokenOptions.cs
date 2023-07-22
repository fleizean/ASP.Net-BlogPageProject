using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Project.Repository.JwtToken
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

