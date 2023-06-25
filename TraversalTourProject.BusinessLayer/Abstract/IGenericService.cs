using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TraversalTourProject.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetListAll();
        T TGetByID(int id);
        //List<T> GetByListFilter(Expression<Func<T, bool>> filter);
    }
}
