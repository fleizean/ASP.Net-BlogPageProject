using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer.Concrete;

namespace Blog_Project.Repository.JwtToken
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AdminUser user);
    }
}

