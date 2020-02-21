using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreSubtitleDAL : EFCoreGenericRepository<Subtitle, SiteContext>, ISubtitleDAL
    {
        public Subtitle GetByIdWithHomepage(int id)
        {
            using (var context = new SiteContext())
            {
                return context.Subtitle
                        .Where(i => i.SubtitleId == id)
                        .Include(i => i.HomeSubtitle)
                        .ThenInclude(i => i.Homepage)
                        .FirstOrDefault();
            }
        }

        public List<Subtitle> GetSubtitleByHome(int homepage)
        {
            using (var context = new SiteContext())
            {
                var Subtitles = context.Subtitle.AsQueryable();
                    Subtitles = Subtitles.Include(i => i.HomeSubtitle).ThenInclude(i => i.Homepage).Where(i => i.HomeSubtitle.Any(a => a.Homepage.HomepageId == homepage));
                return Subtitles.ToList();
            }
        }
    }
}
