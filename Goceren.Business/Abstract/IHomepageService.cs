using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IHomepageService : IRepositoryService<Homepage>
    {
        void Update(Homepage entity, int[] id);
        Homepage GetByIdWithSubtitles(int id);
    }
}
