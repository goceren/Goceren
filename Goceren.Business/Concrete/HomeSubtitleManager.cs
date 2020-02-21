using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class HomeSubtitleManager : IHomeSubtitleService
    {
        private IHomeSubtitleDAL _homesubtitleDal;
        public HomeSubtitleManager(IHomeSubtitleDAL homesubtitleDal)
        {
            _homesubtitleDal = homesubtitleDal;
        }
        public void Create(HomeSubtitle entity)
        {
            _homesubtitleDal.Create(entity);
        }

        public void Delete(HomeSubtitle entity)
        {
            _homesubtitleDal.Delete(entity);
        }

        public List<HomeSubtitle> GetAll()
        {
            return _homesubtitleDal.GetAll().ToList();
        }

        public HomeSubtitle GetById(int id)
        {
            return _homesubtitleDal.GetById(id);
        }

        public HomeSubtitle GetById(int homeId, int subtitleId)
        {
            return _homesubtitleDal.GetById(homeId, subtitleId);
        }

        public void Update(HomeSubtitle entity)
        {
            _homesubtitleDal.Update(entity);
        }
    }
}
