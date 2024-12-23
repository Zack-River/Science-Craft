using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScienceCraft.DataAccess.Data;
using ScienceCraft.Entities.Repos;

namespace ScienceCraft.DataAccess.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICourseRepo Course { get; private set; }
        public ISessionRepo Session { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Course = new CourseRepo(_context);
            Session = new SessionRepo(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
