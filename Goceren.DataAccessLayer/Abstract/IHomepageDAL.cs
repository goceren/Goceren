using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Abstract
{
    public interface IHomepageDAL : IRepository<Homepage>
    {
        void Update(Homepage entity, int[] id);
        Homepage GetByIdWithSubtitles(int id);
    }
}
