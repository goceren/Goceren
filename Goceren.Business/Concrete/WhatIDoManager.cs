using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class WhatIDoManager : IWhatIDoService
    {
        private IWhatIDoDAL _whatidoDal;
        public WhatIDoManager(IWhatIDoDAL whatidoDal)
        {
            _whatidoDal = whatidoDal;
        }
        public WhatIDo GetById(int id)
        {
            return _whatidoDal.GetById(id);
        }

        public List<WhatIDo> GetAll()
        {
            return _whatidoDal.GetAll().ToList();
        }

        public void Create(WhatIDo entity)
        {
            _whatidoDal.Create(entity);
        }

        public void Update(WhatIDo entity)
        {
            _whatidoDal.Update(entity);
        }

        public void Delete(WhatIDo entity)
        {
            _whatidoDal.Delete(entity);
        }

        
    }
}
