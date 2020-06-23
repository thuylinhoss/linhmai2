using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class AboutDAO
    {
        FashionShopDbContext db = null;
        public AboutDAO()
        {
            db = new FashionShopDbContext();
        }


        public long Insert(About entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.About.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(About entity)
        {
            try
            {
                var user = db.About.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    user.Name = entity.Name;
                }
                user.MetaTitle = entity.MetaTitle;
                user.Description = entity.Description;
                user.Image = entity.Image;
                user.Detail = entity.Detail;
                user.CreatedDate = user.CreatedDate;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       

        public IEnumerable<About> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<About> model = db.About;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public About GetByID(string name)
        {
            return db.About.SingleOrDefault(x => x.Name == name);
        }
        public About ViewDetail(int ID)
        {
            return db.About.Find(ID);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.About.Find(id);
                db.About.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
