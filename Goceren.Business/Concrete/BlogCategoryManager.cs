using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class BlogCategoryManager : IBlogCategoryService
    {
        private IBlogCategoryDAL _blogcategoryDal;
        public BlogCategoryManager(IBlogCategoryDAL blogcategoryDal)
        {
            _blogcategoryDal = blogcategoryDal;
        }
        public void Create(BlogCategory entity)
        {
            _blogcategoryDal.Create(entity);
        }

        public void Delete(BlogCategory entity)
        {
            _blogcategoryDal.Delete(entity);
        }

        public List<BlogCategory> GetAll()
        {
            return _blogcategoryDal.GetAll().ToList();
        }

        public BlogCategory GetById(int id)
        {
            return _blogcategoryDal.GetById(id);
        }

        public void Update(BlogCategory entity)
        {
            _blogcategoryDal.Update(entity);
        }
    }
}
