using System.Collections.Generic;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetListAll()
        {
            return _commentDal.GetListAll();
        }

        public List<Comment> TGetDestinationByID(int id)
        {
            return _commentDal.GetByListFilter(x => x.DestinationID == id);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public List<Comment> TGetListCommentDestination()
        {
            return _commentDal.GetListCommentDestination();
        }
    }
}
