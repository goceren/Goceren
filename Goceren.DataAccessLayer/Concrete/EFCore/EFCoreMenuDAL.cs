using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreMenuDAL : EFCoreGenericRepository<Menu, SiteContext>, IMenuDAL
    {
        public IEnumerable<Menu> GetAllWithMenuType()
        {
            using (var context = new SiteContext())
            {
                var menu = context.Menu;
                var menutype = context.MenuType;
                List<Menu> Menues = new List<Menu>();
                foreach (var item in menu)
                {
                    Menu model = new Menu()
                    {
                        isApproved = item.isApproved,
                        MenuId = item.MenuId,
                        MenuTypeId = item.MenuTypeId,
                        MenuLink = item.MenuLink,
                        MenuName = item.MenuName,
                        MenuType = menutype.Where(i => i.MenuTypeId == item.MenuTypeId).FirstOrDefault()
                };
                Menues.Add(model);
            }
            return Menues;
        }
    }


}
}
