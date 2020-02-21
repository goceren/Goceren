using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IEducationService : IRepositoryService<Education>
    {
        IEnumerable<Education> GetAllWithResume();
    }
}
