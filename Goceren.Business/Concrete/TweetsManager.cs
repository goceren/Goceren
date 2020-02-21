using Goceren.Business.Abstract;
using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.Business.Concrete
{
    public class TweetsManager : ITweetsService
    {
        private ITweetsDAL _tweetsDal;
        
        public TweetsManager(ITweetsDAL tweetsDal)
        {
            _tweetsDal = tweetsDal;
        }
        public void Create(Tweets entity)
        {
            _tweetsDal.Create(entity);
        }

        public void Delete(Tweets entity)
        {
            _tweetsDal.Delete(entity);
        }

        public List<Tweets> GetAll()
        {
            return _tweetsDal.GetAll().ToList();
        }

        public Tweets GetById(int id)
        {
            return _tweetsDal.GetById(id);
        }

        public void Update(Tweets entity)
        {
            _tweetsDal.Update(entity);
        }
    }
}
