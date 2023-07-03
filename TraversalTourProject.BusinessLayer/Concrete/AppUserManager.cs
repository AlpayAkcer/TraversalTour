using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TAdd(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void TDelete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public AppUser TGetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> TGetListAll()
        {
            return _appUserDal.GetListAll();
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}
