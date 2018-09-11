using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIPLCollege.Models
{
    public class ManageTeachers
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string ChooseSubject { get; set; }
       }
}