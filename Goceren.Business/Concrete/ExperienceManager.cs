using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private IExperienceDAL _experienceDal;
        public ExperienceManager(IExperienceDAL experienceDal)
        {
            _experienceDal = experienceDal;
        }
        public void Create(Experience entity)
        {
            _experienceDal.Create(entity);
        }

        public void Delete(Experience entity)
        {
            _experienceDal.Delete(entity);
        }

        public List<Experience> GetAll()
        {
            return _experienceDal.GetAll().ToList();
        }

        public IEnumerable<Experience> GetAllWithResume()
        {
            return _experienceDal.GetAllWithResume();
        }

        public Experience GetById(int id)
        {
            return _experienceDal.GetById(id);
        }

        public void Update(Experience entity)
        {
            _experienceDal.Update(entity);
        }
    }
}
