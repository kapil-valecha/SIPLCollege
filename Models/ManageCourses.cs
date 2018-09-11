using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIPLCollege.Models
{
    public class ManageCourses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<ManageSubjects> ManageSubjects { get; set; }
       }
    }