using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class MediumpageManager : IMediumpageService
    {
        private IMediumpageDAL _mediumpageDal;
        public MediumpageManager(IMediumpageDAL mediumpageDal)
        {
            _mediumpageDal = mediumpageDal;
        }
        public void Create(Mediumpage entity)
        {
            _mediumpageDal.Create(entity);
        }

        public void Delete(Mediumpage entity)
        {
            _mediumpageDal.Delete(entity);
        }

        public List<Mediumpage> GetAll()
        {
            return _mediumpageDal.GetAll().ToList();
        }

        public Mediumpage GetById(int id)
        {
            return _mediumpageDal.GetById(id);
        }

        public void Update(Mediumpage entity)
        {
            _mediumpageDal.Update(entity);
        }
    }
}
