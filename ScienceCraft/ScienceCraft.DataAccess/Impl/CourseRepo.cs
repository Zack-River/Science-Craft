using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScienceCraft.DataAccess.Data;
using ScienceCraft.Entities.Models;
using ScienceCraft.Entities.Repos;

namespace ScienceCraft.DataAccess.Impl
{
    public class CourseRepo : GenericRepo<Course> , ICourseRepo
    {
        private readonly AppDbContext _context;
        public CourseRepo(AppDbContext context) : base(context)
        { 
            _context = context;
        }

        public void Update(Course course)
        {
            var CourseInDb = _context.Courses.FirstOrDefault(x => x.Id == course.Id);
            if (CourseInDb != null)
            {
                CourseInDb.Name = course.Name;
                CourseInDb.Description = course.Description;
                CourseInDb.LastModified = DateTime.Now;
            }
        }
    }
}
