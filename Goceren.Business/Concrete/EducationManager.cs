using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class EducationManager : IEducationService
    {
        private IEducationDAL _educationDal;
        public EducationManager(IEducationDAL educationDal)
        {
            _educationDal = educationDal;
        }
        public void Create(Education entity)
        {
            _educationDal.Create(entity);
        }

        public void Delete(Education entity)
        {
            _educationDal.Delete(entity);
        }

        public List<Education> GetAll()
        {
            return _educationDal.GetAll().ToList();
        }

        public IEnumerable<Education> GetAllWithResume()
        {
            return _educationDal.GetAllWithResume().ToList();
        }

        public Education GetById(int id)
        {
            return _educationDal.GetById(id);
        }

        public void Update(Education entity)
        {
            _educationDal.Update(entity);
        }
    }
}
