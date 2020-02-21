using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreEducationDAL : EFCoreGenericRepository<Education, SiteContext>, IEducationDAL
    {
        public IEnumerable<Education> GetAllWithResume()
        {
            using (var context = new SiteContext())
            {
                var resume = context.Resumepage;
                var education = context.Education;
                List<Education> Educations = new List<Education>();
                foreach (var item in education)
                {
                    Education model = new Education()
                    {
                        isApproved = item.isApproved,
                        ResumepageId = item.ResumepageId,
                        Date = item.Date,
                        Description = item.Description,
                        Title = item.Title,
                        EducationType = item.EducationType,
                        EducationId = item.EducationId,
                        Resumepage = resume.Where(i => i.ResumepageId == item.ResumepageId).FirstOrDefault()
                    };
                    Educations.Add(model);
                }
                return Educations;
            }
        }
    }
}
