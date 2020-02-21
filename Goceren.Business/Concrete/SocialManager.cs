using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class SocialManager : ISocialService
    {
        private ISocialDAL _socialDal;
        public SocialManager(ISocialDAL socialDal)
        {
            _socialDal = socialDal;
        }
        public void Create(Social entity)
        {
            _socialDal.Create(entity);
        }

        public void Delete(Social entity)
        {
            _socialDal.Delete(entity);
        }

        public List<Social> GetAll()
        {
            return _socialDal.GetAll().ToList();
        }

        public Social GetById(int id)
        {
            return _socialDal.GetById(id);
        }

        public void Update(Social entity)
        {
            _socialDal.Update(entity);
        }
    }
}
