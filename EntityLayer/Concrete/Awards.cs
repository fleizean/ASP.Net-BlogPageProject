using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Awards
	{
        [Key]
        public int AwardsID { get; set; }
        public string Name { get; set; }
        public string GradePlace { get; set; }
    }
}

