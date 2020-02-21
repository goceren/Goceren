using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Abstract
{
    public interface IBlogDAL: IRepository<Blog>
    {
        List<Blog> GetBlogsByCategory(string category);
        List<Blog> GetAllWithCategory();
        Blog GetBlogDetails(int id);
        void Update(Blog entity, int[] id);

    }
}
