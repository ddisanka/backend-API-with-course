using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentapp.Model
{
    public class Lecturer
    {
        [Key]
        public int LecID { get; set; }
        [Required]
        public string LecFname { get; set; }
        [Required]
        public string LecLname { get; set; }
        [Required]
        public string Lecemail { get; set; }
        [Required]
        public string Lecgender { get; set; }
        [Required]
        public int lecphone { get; set; }
        public string Lectitle { get; set; }
    }
}
