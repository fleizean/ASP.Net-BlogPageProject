using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Education
	{
        [Key]
        public int EducationID { get; set; }
        public string EducationTitle { get; set; }
        public string EducationPlace { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}

