using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductCategoryDAO
    {
        FashionShopDbContext db = null;
        public ProductCategoryDAO()
        {
            db = new FashionShopDbContext();
        }
        public List<DanhMucSP> ListAll()
        {
            return db.DanhMucSP.Where(x => x.Status==true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public List<DanhMucSP> ListAllNu()
        {
            return db.DanhMucSP.Where(x => x.DisplayOrder == 2).OrderBy(x => x.MetaTitle).ToList();
        }
        public List<DanhMucSP> ListAllNam()
        {
            return db.DanhMucSP.Where(x => x.DisplayOrder == 1).OrderBy(x => x.MetaTitle).ToList();
        }
        public DanhMucSP ViewDetail(long id)
        {
            return db.DanhMucSP.Find(id);
        }

    }
}
