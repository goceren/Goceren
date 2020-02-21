using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class SettingsManager : ISettingsService
    {
        private ISettingsDAL _settingsDal;
        public SettingsManager(ISettingsDAL settingsDal)
        {
            _settingsDal = settingsDal;
        }

        public void Create(Settings entity)
        {
            _settingsDal.Create(entity);
        }

        public void Delete(Settings entity)
        {
            _settingsDal.Delete(entity);
        }

        public List<Settings> GetAll()
        {
            return _settingsDal.GetAll().ToList();
        }

        public Settings GetById(int id)
        {
            return _settingsDal.GetById(id);
        }

        public void Update(Settings entity)
        {
            _settingsDal.Update(entity);
        }
    }
}
