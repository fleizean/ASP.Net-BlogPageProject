using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Interests
	{
        [Key]
        public int InterestsID { get; set; }
        public string Description { get; set; }
    }
}

