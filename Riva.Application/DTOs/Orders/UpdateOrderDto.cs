using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Application.DTOs.Orders
{
    public class UpdateOrderDto
    {
        public int OrdersID { get; set; }
        public string POInternal { get; set; }
        public string POExternal { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int CustomerID { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? TotalShippedDate { get; set; }
        public int OrderStatusID { get; set; }
        public string Comment { get; set; }
    }
}
