using System;
using System.Collections.Generic;

namespace avanceradnet_labb2_linq.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public int CourseId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Teacher? Teacher { get; set; }
    }
}
