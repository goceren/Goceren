using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class HomepageManager : IHomepageService
    {
        private IHomepageDAL _homepageDal;
        public HomepageManager(IHomepageDAL homepageDal)
        {
            _homepageDal = homepageDal;
        }

        public void Create(Homepage entity)
        {
            _homepageDal.Create(entity);
        }

        public void Update(Homepage entity, int[] id)
        {
            _homepageDal.Update(entity, id);
        }

        public void Delete(Homepage entity)
        {
            _homepageDal.Delete(entity);
        }

        public List<Homepage> GetAll()
        {
            return _homepageDal.GetAll().ToList();
        }

        public Homepage GetById(int id)
        {
            return _homepageDal.GetById(id);
        }

        public void Update(Homepage entity)
        {
            _homepageDal.Update(entity);
        }
        public Homepage GetByIdWithSubtitles(int id)
        {
            return _homepageDal.GetByIdWithSubtitles(id);
        }
    }
}
