using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IResumepageService : IRepositoryService<Resumepage>
    {
        IEnumerable<Resumepage> GetAllWithObjects();
        Resumepage GetByIdWithObjects(int id);
    }
}
