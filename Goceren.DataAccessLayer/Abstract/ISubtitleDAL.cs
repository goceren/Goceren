using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Goceren.DataAccessLayer.Abstract
{
    public interface ISubtitleDAL : IRepository<Subtitle>
    {
        List<Subtitle> GetSubtitleByHome(int homepage);
        Subtitle GetByIdWithHomepage(int id);
    }
}
