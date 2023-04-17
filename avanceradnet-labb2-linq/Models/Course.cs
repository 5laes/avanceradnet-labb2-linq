using System;
using System.Collections.Generic;

namespace avanceradnet_labb2_linq.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
