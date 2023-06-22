using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TraversalTourProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetListAll();
        T GetByID(int id);

        //Şarta göre filtreleme yapıp veri getirme.
        List<T> GetByListFilter(Expression<Func<T, bool>> filter);
    }
}
