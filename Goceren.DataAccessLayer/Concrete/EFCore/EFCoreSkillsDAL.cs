using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreSkillsDAL : EFCoreGenericRepository<Skills, SiteContext>, ISkillsDAL
    {
        public IEnumerable<Skills> GetAllWithResume()
        {            
            using (var context = new SiteContext())
            {
                var resume = context.Resumepage;
                var skill = context.Skills;
                List<Skills> Skill = new List<Skills>();
                foreach (var item in skill)
                {
                    Skills model = new Skills()
                    {
                        isApproved = item.isApproved,
                        ResumepageId = item.ResumepageId,
                        SkillPercent = item.SkillPercent,
                        SkillTitle = item.SkillTitle,
                        SkillsId = item.SkillsId,
                        Resumepage = resume.Where(i => i.ResumepageId == item.ResumepageId).FirstOrDefault()
                    };
                    Skill.Add(model);
                }
                return Skill;
            }
        }
    }
}
