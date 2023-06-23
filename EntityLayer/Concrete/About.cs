using System;
using System.ComponentModel.DataAnnotations;
namespace EntityLayer.Concrete
{
	public class About
	{
        [Key]
        public int AboutID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ShortAddress { get; set; }
        public string LongAddress { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}

