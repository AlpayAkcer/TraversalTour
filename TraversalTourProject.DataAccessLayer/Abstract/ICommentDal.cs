using System.Collections.Generic;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentDestination();
    }
}
