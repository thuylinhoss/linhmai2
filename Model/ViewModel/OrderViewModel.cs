using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewModel
    {
        public long ID { set; get; }
        public long UserID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? DeliverDate { set; get; }
        public bool? Status { set; get; }

    }
}
