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
    public class SessionRepo : GenericRepo<Session>, ISessionRepo
    {
        private readonly AppDbContext _context;
        public SessionRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Session session)
        {
            var SessionInDb = _context.Sessions.FirstOrDefault(x => x.Id == session.Id);
            if (SessionInDb != null)
            {
                SessionInDb.Name = session.Name;
                SessionInDb.Description = session.Description;
                SessionInDb.LastModified = DateTime.Now;
                SessionInDb.Content = session.Content;
                SessionInDb.KitId = session.KitId;
                SessionInDb.CourseId = session.CourseId;
                SessionInDb.InscId = session.InscId;
            }
        }
    }
}
