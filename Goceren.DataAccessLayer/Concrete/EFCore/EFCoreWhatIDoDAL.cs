﻿using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreWhatIDoDAL : EFCoreGenericRepository<WhatIDo, SiteContext>, IWhatIDoDAL
    {
    }
}
