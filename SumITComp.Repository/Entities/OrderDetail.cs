using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SumITComp.Repository.Entities;

namespace SumITComp.Repository
{
    public class OrderDetail
    {

        public int Id { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        //Navigate
        public virtual Product Product{ get; set; }
        public virtual Order Order { get; set; }
    }
}
