using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IBlogService : IRepositoryService<Blog>
    {
        Blog GetBlogDetails(int id);
        List<Blog> GetBlogsByCategory(string category);
        List<Blog> GetAllWithCategory();
        void Update(Blog entity, int[] id);

    }
}
