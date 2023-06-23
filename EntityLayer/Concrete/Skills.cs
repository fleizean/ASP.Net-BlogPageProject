using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Skills
	{
        [Key]
        public int SkillsID { get; set; }
        public string Name { get; set; }
        public string ExperienceDescription { get; set; }
    }
}

