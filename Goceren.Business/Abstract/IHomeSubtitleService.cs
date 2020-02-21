using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface IHomeSubtitleService : IRepositoryService<HomeSubtitle>
    {
        HomeSubtitle GetById(int homeId, int subtitleId);
    }
}
