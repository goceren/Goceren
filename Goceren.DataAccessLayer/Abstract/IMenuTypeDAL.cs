using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Abstract
{
    public interface IMenuTypeDAL : IRepository<MenuType>
    {
        IEnumerable<MenuType> GetAllWithObjects();
        MenuType GetByIdWithObjects(int id);
    }
}
