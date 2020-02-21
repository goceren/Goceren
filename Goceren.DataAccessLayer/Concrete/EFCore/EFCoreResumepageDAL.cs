using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreResumepageDAL : EFCoreGenericRepository<Resumepage, SiteContext>, IResumepageDAL
    {
        public IEnumerable<Resumepage> GetAllWithObjects()
        {
            using (var context = new SiteContext())
            {
                var skills = context.Skills;
                var educations = context.Education;
                var experiences = context.Experience;
                var resumepage = context.Resumepage;
                List<Resumepage> Resumepages = new List<Resumepage>();
                foreach (var item in resumepage)
                {
                    Resumepage model = new Resumepage()
                    {
                        isApproved = item.isApproved,
                        ResumepageId = item.ResumepageId,
                        CVLink = item.CVLink,
                        LeftBottomTitle = item.LeftBottomTitle,
                        Subtitle = item.Subtitle,
                        RightTopTitle = item.RightTopTitle,
                        ResumepageTitle = item.ResumepageTitle,
                        LeftTopTitle = item.LeftTopTitle,
                        Educations = educations.Where(i => i.ResumepageId == item.ResumepageId).ToList(),
                        Skills = skills.Where(i => i.ResumepageId == item.ResumepageId).ToList(),
                        Experiences = experiences.Where(i => i.ResumepageId == item.ResumepageId).ToList() 
                   };
                    Resumepages.Add(model);
                }
                return Resumepages;
            }
        }

        public Resumepage GetByIdWithObjects(int id)
        {
            using (var context = new SiteContext())
            {
                var skills = context.Skills;
                var educations = context.Education;
                var experiences = context.Experience;
                var resumepage = context.Resumepage.Find(id);
                resumepage.Skills = skills.Where(i => i.ResumepageId == id).ToList();
                resumepage.Educations = educations.Where(i => i.ResumepageId == id).ToList();
                resumepage.Experiences = experiences.Where(i => i.ResumepageId == id).ToList();
                return resumepage;
            }
        }
    }
}
