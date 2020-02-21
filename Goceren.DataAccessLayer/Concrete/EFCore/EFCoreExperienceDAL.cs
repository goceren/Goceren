using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreExperienceDAL : EFCoreGenericRepository<Experience, SiteContext>, IExperienceDAL
    {
        public IEnumerable<Experience> GetAllWithResume()
        {
            using (var context = new SiteContext())
            {
                var resume = context.Resumepage;
                var experience = context.Experience;
                List<Experience> Experiences = new List<Experience>();
                foreach (var item in experience)
                {
                    Experience model = new Experience()
                    {
                        isApproved = item.isApproved,
                        ResumepageId = item.ResumepageId,
                        Date = item.Date,
                        Description = item.Description,
                        Title = item.Title,
                        CompanyName = item.CompanyName,
                        ExperienceId = item.ExperienceId,
                        Resumepage = resume.Where(i => i.ResumepageId == item.ResumepageId).FirstOrDefault()
                    };
                    Experiences.Add(model);
                }
                return Experiences;
            }
        }
    }
}
