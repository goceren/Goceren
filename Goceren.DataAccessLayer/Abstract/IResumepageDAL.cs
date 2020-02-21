using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Abstract
{
    public interface IResumepageDAL : IRepository<Resumepage>
    {
        IEnumerable<Resumepage> GetAllWithObjects();
        Resumepage GetByIdWithObjects(int id);
    }
}
