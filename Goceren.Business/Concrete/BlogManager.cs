using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDAL _blogDal;
        public BlogManager(IBlogDAL blogDal)
        {
            _blogDal = blogDal;
        }
        public void Create(Blog entity)
        {
            _blogDal.Create(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll().ToList();
        }

        public List<Blog> GetAllWithCategory()
        {
            return _blogDal.GetAllWithCategory();
        }

        public Blog GetBlogDetails(int id)
        {
            return _blogDal.GetBlogDetails(id);
        }

        public List<Blog> GetBlogsByCategory(string category)
        {
            return _blogDal.GetBlogsByCategory(category);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public void Update(Blog entity, int[] id)
        {
            _blogDal.Update(entity, id);
        }
    }
}
