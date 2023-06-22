using System;
using System.Collections.Generic;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.BusinessLayer.Concrete
{
    public class FeaturedManager : IFeaturedService
    {
        public IFeaturedDal _featuredDal;

        public FeaturedManager(IFeaturedDal featuredDal)
        {
            _featuredDal = featuredDal;
        }

        public void TAdd(Featured entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Featured entity)
        {
            throw new NotImplementedException();
        }

        public Featured TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Featured> TGetListAll()
        {
            return _featuredDal.GetListAll();
        }

        public void TUpdate(Featured entity)
        {
            throw new NotImplementedException();
        }
    }
}
