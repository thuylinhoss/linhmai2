using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderDetailViewModel
    {
        public long OrderID { set; get; }
        public long ProductID { set; get; }
        public int Quantity { set; get; }
        public decimal? Price { set; get; }
    }
}
