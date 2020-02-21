using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class BlogpageManager : IBlogpageService
    {
        private IBlogpageDAL _blogpageDal;
        public BlogpageManager(IBlogpageDAL blogpageDal)
        {
            _blogpageDal = blogpageDal;
        }
        public void Create(Blogpage entity)
        {
            _blogpageDal.Create(entity);
        }

        public void Delete(Blogpage entity)
        {
            _blogpageDal.Delete(entity);
        }

        public List<Blogpage> GetAll()
        {
            return _blogpageDal.GetAll().ToList();
        }

        public Blogpage GetById(int id)
        {
            return _blogpageDal.GetById(id);
        }

        public void Update(Blogpage entity)
        {
            _blogpageDal.Update(entity);
        }
    }
}
