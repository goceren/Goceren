using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Abstract
{
    public interface IHomeSubtitleDAL : IRepository<HomeSubtitle>
    {
        HomeSubtitle GetById(int homeId, int subtitleId);
    }
}
