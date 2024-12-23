using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceCraft.Entities.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepo Course { get; }
        ISessionRepo Session { get; }
        int Complete();
    }
}
