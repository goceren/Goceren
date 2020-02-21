using Goceren.DataAccessLayer.Abstract;
using Goceren.DataAccessLayer.Concrete.EFCore;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete
{
    public class EFCoreNavbarDAL : EFCoreGenericRepository<Navbar, SiteContext>, INavbarDAL
    {
        
    }
}
 