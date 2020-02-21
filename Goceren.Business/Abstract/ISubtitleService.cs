using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.Business.Abstract
{
    public interface ISubtitleService : IRepositoryService<Subtitle>
    {
        List<Subtitle> GetSubtitleByHome(int homepage);
        Subtitle GetByIdWithHomepage(int id);

    }
}
