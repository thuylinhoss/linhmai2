using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class FeedbackDAO
    {
        FashionShopDbContext db = null;
        public FeedbackDAO()
        {
            db = new FashionShopDbContext();
        }

        public long Insert(Feedback entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Feedback.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Feedback GetByID(long id)
        {
            return db.Feedback.Find(id);
        }

        public bool Update(Feedback entity)
        {
            try
            {
                var fb = db.Feedback.Find(entity.ID);
                fb.Name = entity.Name;
                fb.Phone = entity.Phone;
                fb.Email = entity.Email;
                fb.Address = entity.Address;
                fb.Content = entity.Content;
                fb.CreatedDate = entity.CreatedDate;
                fb.Status = entity.Status;
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
            var product = db.Feedback.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }

        public bool Delete(long id)
        {
            try
            {
                var product = db.Feedback.Find(id);
                db.Feedback.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Feedback> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedback;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        //public List<Feedback> ListAll(int type)
        //{
        //    return db.Feedback.Where(x => x.N == type && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        //}
        public Feedback ViewDetail(int ID)
        {
            return db.Feedback.Find(ID);
        }
    }
}
