using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class SubtitleManager : ISubtitleService
    {
        private ISubtitleDAL _subtitleDal;
        public SubtitleManager(ISubtitleDAL subtitleDal)
        {
            _subtitleDal = subtitleDal;
        }
        public void Create(Subtitle entity)
        {
            _subtitleDal.Create(entity);
        }

        public void Delete(Subtitle entity)
        {
            _subtitleDal.Delete(entity);
        }

        public List<Subtitle> GetAll()
        {
            return _subtitleDal.GetAll().ToList();
        }

        public Subtitle GetById(int id)
        {
            return _subtitleDal.GetById(id);
        }

        public Subtitle GetByIdWithHomepage(int id)
        {
            return _subtitleDal.GetByIdWithHomepage(id);
        }

        public List<Subtitle> GetSubtitleByHome(int homepage)
        {
            return _subtitleDal.GetSubtitleByHome(homepage);
        }

        public void Update(Subtitle entity)
        {
            _subtitleDal.Update(entity);
        }
    }
}
