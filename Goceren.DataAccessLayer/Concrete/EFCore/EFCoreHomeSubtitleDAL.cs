using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreHomeSubtitleDAL : EFCoreGenericRepository<HomeSubtitle, SiteContext>, IHomeSubtitleDAL
    {
        public HomeSubtitle GetById(int homeId, int subtitleId)
        {
            using (var context = new SiteContext())
            {
                return context.Set<HomeSubtitle>().Find(homeId, subtitleId);
            }
        }
    }
}
