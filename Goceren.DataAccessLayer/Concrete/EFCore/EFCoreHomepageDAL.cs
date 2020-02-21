using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreHomepageDAL : EFCoreGenericRepository<Homepage, SiteContext>, IHomepageDAL
    {
        public Homepage GetByIdWithSubtitles(int id)
        {
            using (var context = new SiteContext())
            {
                return context.Homepage
                        .Where(i => i.HomepageId == id)
                        .Include(i => i.HomeSubtitle)
                        .ThenInclude(i => i.Subtitle)
                        .FirstOrDefault();
            }
        }

        public void Update(Homepage entity, int[] id)
        {
            using (var context = new SiteContext())
            {
                var homepage = context.Homepage
                                   .Include(i => i.HomeSubtitle)
                                   .FirstOrDefault(i => i.HomepageId == entity.HomepageId);

                if (homepage != null)
                {
                    homepage.Title = entity.Title;
                    homepage.AboutBottom = entity.AboutBottom;
                    homepage.AboutTop = entity.AboutTop;
                    homepage.AboutImage = entity.AboutImage;
                    homepage.CVLink = entity.CVLink;
                    homepage.isApproved = entity.isApproved;

                    homepage.HomeSubtitle = id.Select(catid => new HomeSubtitle()
                    {
                        SubtitleId = catid,
                        HomepageId = entity.HomepageId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
