using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDAO
    {
        FashionShopDbContext db = null;
        public MenuDAO()
        {
            db = new FashionShopDbContext();
        }
        
        public List<Menu> ListByTypeID(int TypeID)
        {
            return db.Menu.Where(x => x.TypeID == TypeID).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
