using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class ResumepageManager : IResumepageService
    {
        private readonly IResumepageDAL _resumepageDal;
        public ResumepageManager(IResumepageDAL resumepageDal)
        {
            _resumepageDal = resumepageDal;
        }
        public void Create(Resumepage entity)
        {
            _resumepageDal.Create(entity);
        }

        public void Delete(Resumepage entity)
        {
            _resumepageDal.Delete(entity);
        }

        public List<Resumepage> GetAll()
        {
            return _resumepageDal.GetAll().ToList();
        }

        public IEnumerable<Resumepage> GetAllWithObjects()
        {
            return _resumepageDal.GetAllWithObjects();
        }

        public Resumepage GetById(int id)
        {
            return _resumepageDal.GetById(id);
        }

        public Resumepage GetByIdWithObjects(int id)
        {
            return _resumepageDal.GetByIdWithObjects(id);
        }

        public void Update(Resumepage entity)
        {
            _resumepageDal.Update(entity);
        }
    }
}
