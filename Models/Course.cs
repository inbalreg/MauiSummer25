using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSummer25.Models
{
    [Table("Courses")]
    public class Course
    {
      
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int HoursNum { get; set; }
    }
}
