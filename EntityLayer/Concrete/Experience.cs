using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Experience
	{
        [Key]
        public int ExperienceID { get; set; }
        public string JobTitle { get; set; }
        public string WorkPlace { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}

