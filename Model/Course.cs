using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentapp.Model
{
    public class Course
    {
        [Key]
        public int CrseCode { get; set; }
        [Required]
        public string CrseTitle { get; set; }
        [Required]
        public int CrsCredits { get; set; }
        [Required]
        public string CrsDescription {get;set;}
    }
}
