using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class ProductDAO
    {
        FashionShopDbContext db = null;
        public ProductDAO()
        {
            db = new FashionShopDbContext();
        }
        public long Insert(SanPham entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.SanPham.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public SanPham GetByID(long id)
        {
            return db.SanPham.Find(id);
        }

        public bool Update(SanPham entity)
        {
            try
            {
                var product = db.SanPham.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.MoreImages = entity.MoreImages;
                product.ID_DanhMuc = entity.ID_DanhMuc;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.Quantity = entity.Quantity;
                product.CreatedDate = entity.CreatedDate;
                product.ModifiedDate = DateTime.Now;
                product.Gender = entity.Gender;
                product.Top = entity.Top;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<SanPham> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPham;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool ChangeStatus(long id)
        {
            var product = db.SanPham.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }

        public bool ChangeTop(long id)
        {
            var product = db.SanPham.Find(id);
            product.Top = !product.Top;
            db.SaveChanges();
            return product.Top;
        }

        public bool Delete(long id)
        {
            try
            {
                var product = db.SanPham.Find(id);
                db.SanPham.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<SanPham> ListByCategoryID(long cateID, ref int totalRecord, int page = 1, int pageSize = 2)
        {
            totalRecord = db.SanPham.Where(x => x.ID_DanhMuc == cateID).Count();
            var model = db.SanPham.Where(x => x.ID_DanhMuc == cateID).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        public List<SanPham> ListNewProduct(int top)
        {
            return db.SanPham.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<SanPham> ListFeatureProduct(int top)
        {
            return db.SanPham.Where(x => x.Top == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<SanPham> ListSaleProducts(int top)
        {
            return db.SanPham.Where(x => x.PromotionPrice != null).OrderByDescending(x => x.PromotionPrice).Take(top).ToList();
        }
        public List<SanPham> ListTop1NuProduct(int top)
        {
            return db.SanPham.Where(x => x.Top == true && x.Gender == false).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<SanPham> ListTop2NuProduct(int top)
        {
            return db.SanPham.Where(x => x.Top == false && x.Gender == false).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<SanPham> ListTop1NamProduct(int top)
        {
            return db.SanPham.Where(x => x.Top == true && x.Gender == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<SanPham> ListTop2NamProduct(int top)
        {
            return db.SanPham.Where(x => x.Top == false && x.Gender == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public SanPham ViewDetail(long id)
        {
            return db.SanPham.Find(id);
        }

    }
}
