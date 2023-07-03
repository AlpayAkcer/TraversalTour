using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Repository;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
    }
}
