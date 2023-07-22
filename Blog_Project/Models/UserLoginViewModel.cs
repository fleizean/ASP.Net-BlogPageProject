using System;
using System.ComponentModel.DataAnnotations;

namespace Blog_Project.Models
{
	public class UserLoginViewModel
	{
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
    }
}

