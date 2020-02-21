using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Abstract
{
    public interface IExperienceDAL : IRepository<Experience>
    {
        IEnumerable<Experience> GetAllWithResume();
    }
}