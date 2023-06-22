using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Concrete;

namespace TraversalTourProject.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using Context _context = new Context();
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetListAll()
        {
            using Context _context = new Context();
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            using Context _context = new Context();
            _context.Add(entity);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            using Context _context = new Context();
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            using Context _context = new Context();
            _context.Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetByListFilter(Expression<Func<T, bool>> filter)
        {
            using Context _context = new Context();
            return _context.Set<T>().Where(filter).ToList();
        }
    }
}
