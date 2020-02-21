using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private IMenuDAL _menuDal;
        public MenuManager(IMenuDAL menuDal)
        {
            _menuDal = menuDal;
        }
        public void Create(Menu entity)
        {
            _menuDal.Create(entity);
        }

        public void Delete(Menu entity)
        {
            _menuDal.Delete(entity);
        }

        public List<Menu> GetAll()
        {
            return _menuDal.GetAll().ToList();
        }

        public IEnumerable<Menu> GetAllWithMenuType()
        {
            return _menuDal.GetAllWithMenuType().ToList();
        }

        public Menu GetById(int id)
        {
            return _menuDal.GetById(id);
        }

        public void Update(Menu entity)
        {
            _menuDal.Update(entity);
        }
    }
}
