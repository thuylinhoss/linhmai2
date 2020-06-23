using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;

namespace Model.DAO
{
    public class OrderDetailDAO
    {
        FashionShopDbContext db = null;
        public OrderDetailDAO()
        {
            db = new FashionShopDbContext();
        }
        public bool Insert(OrderDetailViewModel orderDetail)
        {
            try
            {
                ChiTietHoaDon Chitiet = new ChiTietHoaDon();
                Chitiet.ID_HoaDon = orderDetail.OrderID;
                Chitiet.ID_SanPham = orderDetail.ProductID;
                Chitiet.ID_Size = 3;
                Chitiet.Quantity = orderDetail.Quantity;
                Chitiet.Price = orderDetail.Price*orderDetail.Quantity;
                db.ChiTietHoaDon.Add(Chitiet);
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
