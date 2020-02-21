using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.Memory
{
    public class MemoryNavbarDAL : INavbarDAL
    {
        public void Create(Navbar entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Navbar entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Navbar> GetAll(Expression<Func<Navbar, bool>> filter = null)
        {
            var navbars = new List<Navbar>()
            {
                new Navbar(){ NavbarId = 1, NavbarTitle = "Veli", Cpyright="Yavuz", NavbarImage="Deneme"}
            };
            return navbars;
        }

        public Navbar GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Navbar GetOne(Expression<Func<Navbar, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Navbar entity)
        {
            throw new NotImplementedException();
        }
    }
}
