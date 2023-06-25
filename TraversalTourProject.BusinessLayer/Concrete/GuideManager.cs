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
    public class GuideManager : IGuideService
    {
        public IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide entity)
        {
            _guideDal.Insert(entity);
        }

        public void TDelete(Guide entity)
        {
            _guideDal.Delete(entity);
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> TGetListAll()
        {
            return _guideDal.GetListAll();
        }

        public void TUpdate(Guide entity)
        {
            _guideDal.Update(entity);
        }
    }
}
