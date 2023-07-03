using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.Repository;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentDestination()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Destination).ToList();
            }
        }
    }
}
