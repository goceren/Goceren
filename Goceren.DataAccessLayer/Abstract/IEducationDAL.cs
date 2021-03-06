﻿using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Goceren.DataAccessLayer.Abstract
{
    public interface IEducationDAL : IRepository<Education>
    {
        IEnumerable<Education> GetAllWithResume();
    }
}
