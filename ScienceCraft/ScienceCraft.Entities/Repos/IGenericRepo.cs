using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScienceCraft.Entities.Repos
{
    public interface IGenericRepo<T> where T : class
    {
        // _context.Entity.Include("Sessions").ToList();
        // _context.Entity.Where(x => x.Id == id).ToList();
        IEnumerable<T> GetAll(Expression<Func<T , bool>>? perdicate = null , string? IncludeWord = null);

        // _context.Entity.Include("Sessions").SingleOrDefault();
        // _context.Entity.Where(x => x.Id == id).SingleOrDefault();
        T GetFirstOrDefault(Expression<Func<T, bool>>? perdicate = null, string? IncludeWord = null);
        
        // _context.Entity.Add(Entity)
        void Add(T entity);

        // _context.Entity.Remove(Entity)
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
