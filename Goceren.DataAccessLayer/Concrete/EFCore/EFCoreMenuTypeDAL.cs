using Goceren.DataAccessLayer.Abstract;
using Goceren.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goceren.DataAccessLayer.Concrete.EFCore
{
    public class EFCoreMenuTypeDAL : EFCoreGenericRepository<MenuType, SiteContext>, IMenuTypeDAL
    {
        public IEnumerable<MenuType> GetAllWithObjects()
        {
            using (var context = new SiteContext())
            {
                var menu = context.Menu;
                var menutypes = context.MenuType;
                List<MenuType> MenuTypes = new List<MenuType>();
                foreach (var item in menutypes)
                {
                    MenuType model = new MenuType()
                    {
                        MenuTypeName = item.MenuTypeName,
                        MenuTypeId = item.MenuTypeId,
                        Menus = menu.Where(i => i.MenuTypeId == item.MenuTypeId).ToList()
                    };
                    MenuTypes.Add(model);
                }
                return MenuTypes;
            }
        }

        public MenuType GetByIdWithObjects(int id)
        {
            using (var context = new SiteContext())
            {
                var menu = context.Menu;
                var menutypes = context.MenuType.Find(id);
                menutypes.Menus = menu.Where(i => i.MenuTypeId == id).ToList();
                return menutypes;
            }
        }
    }
}
