using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ScienceCraft.Entities.Models;

namespace ScienceCraft.Entities.Viewmodels
{
    public class CourseSessions
    {
        public Course course { get; set; }
        //public Kit kit { get; set; }
        //public Employee Instructor { get; set; }
        
        [ValidateNever]
        public IEnumerable<Session>? Sessions { get; set; }
    }
}
