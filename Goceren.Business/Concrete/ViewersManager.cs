using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class ViewersManager : IViewersService
    {
        private IViewersDAL _viewersDal;
        public ViewersManager(IViewersDAL viewersDal)
        {
            _viewersDal = viewersDal;
        }
        public void Create(Viewers entity)
        {
            _viewersDal.Create(entity);
        }

        public void Delete(Viewers entity)
        {
            _viewersDal.Delete(entity);
        }

        public List<Viewers> GetAll()
        {
            return _viewersDal.GetAll().ToList();
        }

        public Viewers GetById(int id)
        {
            return _viewersDal.GetById(id);
        }

        public void Update(Viewers entity)
        {
            _viewersDal.Update(entity);
        }
    }
}
