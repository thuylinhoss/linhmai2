using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SlideDAO
    {
        FashionShopDbContext db = null;
        public SlideDAO()
        {
            db = new FashionShopDbContext();
        }
        public List<Slide> ListAll(int type)
        {
            return db.Slide.Where(x => x.SlideType == type && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
