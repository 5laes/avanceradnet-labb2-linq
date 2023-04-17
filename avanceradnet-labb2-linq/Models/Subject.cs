using System;
using System.Collections.Generic;

namespace avanceradnet_labb2_linq.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
