using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class NavbarManager : INavbarService
    {
        private INavbarDAL _navbarDAL;
        public NavbarManager(INavbarDAL navbarDAL)
        {
            _navbarDAL = navbarDAL;
        }
        public void Create(Navbar entity)
        {
            _navbarDAL.Create(entity);
        }

        public void Delete(Navbar entity)
        {
            _navbarDAL.Delete(entity);
        }

        public List<Navbar> GetAll()
        {
            return _navbarDAL.GetAll().ToList();
        }

        public Navbar GetById(int id)
        {
            return _navbarDAL.GetById(id);
        }

        public void Update(Navbar entity)
        {
            _navbarDAL.Update(entity);
        }
    }
}
