using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIPLCollege.Models
{
    public class ManageSubjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public virtual ManageCourses ManageCourses { get; set; }
    }
}