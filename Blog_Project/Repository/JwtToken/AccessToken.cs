using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Project.Repository.JwtToken
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}

