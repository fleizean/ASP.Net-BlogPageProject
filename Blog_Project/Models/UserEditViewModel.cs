using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Project.Models
{
	public class UserEditViewModel
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string PasswordConfirm { get; set; }
        public string PictureUrl { get; set; }
        public IFormFile Picture { get; set; }
    }
}

