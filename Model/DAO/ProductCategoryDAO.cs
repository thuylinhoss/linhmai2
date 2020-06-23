using Model.EF;
using PagedList;
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

        public long Insert(DanhMucSP entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.DanhMucSP.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public DanhMucSP GetByID(long id)
        {
            return db.DanhMucSP.Find(id);
        }

        public bool Update(DanhMucSP entity)
        {
            try
            {
                var product = db.DanhMucSP.Find(entity.ID);
                product.Name = entity.Name;
                product.MetaTitle = entity.MetaTitle;
                product.DisplayOrder = entity.DisplayOrder;
                product.CreatedDate = entity.CreatedDate;
                product.ModifiedDate = DateTime.Now;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ChangeStatus(long id)
        {
            var product = db.DanhMucSP.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }

        public bool Delete(long id)
        {
            try
            {
                var product = db.DanhMucSP.Find(id);
                db.DanhMucSP.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<DanhMucSP> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DanhMucSP> model = db.DanhMucSP;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
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
