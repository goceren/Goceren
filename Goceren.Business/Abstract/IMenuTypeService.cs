using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IMenuTypeService : IRepositoryService<MenuType>
    {
        IEnumerable<MenuType> GetAllWithObjects();
        MenuType GetByIdWithObjects(int id);
    }
}
