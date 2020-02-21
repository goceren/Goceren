using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IExperienceService : IRepositoryService<Experience>
    {
        IEnumerable<Experience> GetAllWithResume();

    }
}
