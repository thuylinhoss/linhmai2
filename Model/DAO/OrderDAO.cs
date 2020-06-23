using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;
using Model.EF;

namespace Model.DAO
{
    public class OrderDAO
    {
        FashionShopDbContext db = null;
        public OrderDAO()
        {
            db = new FashionShopDbContext();
        }
        public long Insert(OrderViewModel Order)
        {
            HoaDon hd = new HoaDon();
            hd.CreatedDate = Order.CreatedDate;
            hd.ID_User = Order.UserID;
            hd.Status = false;
            db.HoaDon.Add(hd);
            db.SaveChanges();
            //Order.ID=hd.ID;
            return hd.ID;
        }
    }
}
