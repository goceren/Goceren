using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface ISkillsService : IRepositoryService<Skills>
    {
        IEnumerable<Skills> GetAllWithResume();
    }
}
