using System.Collections.Generic;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        //Generic servis yerine bağlı bulunduğu ICommentservice'e de tanımlama yapılabilir.
        //Bu overide method gibi görünebilir ama managerda kullanılabilir.
        // Başka methodlar olursa onları da buraya tanımlayabiliriz.
        public List<Comment> TGetDestinationByID(int id);
        public List<Comment> TGetListCommentDestination();
    }
}
