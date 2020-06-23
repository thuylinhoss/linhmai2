using Model.EF;
using PagedList;
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


        public long Insert(Slide entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Slide.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Slide entity)
        {
            try
            {
                var user = db.Slide.Find(entity.ID);
                user.Image = entity.Image;
                
                user.DisplayOrder = entity.DisplayOrder;
                user.Description = entity.Description;
                user.Link = entity.Link;
                user.CreatedDate = entity.CreatedDate;
                user.ModifiedDate = DateTime.Now;
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
            var user = db.Slide.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public IEnumerable<Slide> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slide;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Image.Contains(searchString) || x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Slide GetByID(string img)
        {
            return db.Slide.SingleOrDefault(x => x.Image == img);
        }
        public Slide ViewDetail(int ID)
        {
            return db.Slide.Find(ID);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Slide.Find(id);
                db.Slide.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Slide> ListAll(int type)
        {
            return db.Slide.Where(x => x.SlideType == type && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
