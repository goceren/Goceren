using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Goceren.DataAccessLayer.Abstract
{
    public interface IMenuDAL : IRepository<Menu>
    {
        IEnumerable<Menu> GetAllWithMenuType();
    }
}
