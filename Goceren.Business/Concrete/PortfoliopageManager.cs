using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class PortfoliopageManager : IPortfoliopageService
    {
        private IPortfoliopageDAL _portfoliopageDal;
        public PortfoliopageManager(IPortfoliopageDAL portfoliopageDal)
        {
            _portfoliopageDal = portfoliopageDal;
        }
        public void Create(Portfoliopage entity)
        {
            _portfoliopageDal.Create(entity);
        }

        public void Delete(Portfoliopage entity)
        {
            _portfoliopageDal.Delete(entity);
        }

        public List<Portfoliopage> GetAll()
        {
            return _portfoliopageDal.GetAll().ToList();
        }

        public Portfoliopage GetById(int id)
        {
            return _portfoliopageDal.GetById(id);
        }

        public void Update(Portfoliopage entity)
        {
            _portfoliopageDal.Update(entity);
        }
    }
}
