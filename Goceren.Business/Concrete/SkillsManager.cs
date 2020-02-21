using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class SkillsManager : ISkillsService
    {
        private ISkillsDAL _skillsDal;
        public SkillsManager(ISkillsDAL skillsDal)
        {
            _skillsDal = skillsDal;
        }
        public void Create(Skills entity)
        {
            _skillsDal.Create(entity);
        }

        public void Delete(Skills entity)
        {
            _skillsDal.Delete(entity);
        }

        public List<Skills> GetAll()
        {
            return _skillsDal.GetAll().ToList();
        }

        public IEnumerable<Skills> GetAllWithResume()
        {
            return _skillsDal.GetAllWithResume().ToList();
        }

        public Skills GetById(int id)
        {
            return _skillsDal.GetById(id);
        }

        public void Update(Skills entity)
        {
            _skillsDal.Update(entity);
        }
    }
}
