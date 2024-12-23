using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScienceCraft.Entities.Models;

namespace ScienceCraft.Entities.Repos
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        void Update(Course course);
    }
}
