using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class MenuTypeManager : IMenuTypeService
    {
        private IMenuTypeDAL _menutypeDal;
        public MenuTypeManager(IMenuTypeDAL menutypeDal)
        {
            _menutypeDal = menutypeDal;
        }
        public void Create(MenuType entity)
        {
            _menutypeDal.Create(entity);
        }

        public void Delete(MenuType entity)
        {
            _menutypeDal.Delete(entity);
        }

        public List<MenuType> GetAll()
        {
            return _menutypeDal.GetAll().ToList();
        }

        public IEnumerable<MenuType> GetAllWithObjects()
        {
            return _menutypeDal.GetAllWithObjects().ToList();
        }

        public MenuType GetById(int id)
        {
            return _menutypeDal.GetById(id);
        }

        public MenuType GetByIdWithObjects(int id)
        {
            return _menutypeDal.GetByIdWithObjects(id);
        }

        public void Update(MenuType entity)
        {
            _menutypeDal.Update(entity);
        }
    }
}
