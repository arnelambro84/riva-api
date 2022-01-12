using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Application.DTOs.OrderDetails
{
    public class UpdateOrderDetailsDto
    {
        public int OrdersDetailsID { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyShipped { get; set; }
        public int QtyInvoiced { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustAdrsID { get; set; }
        public string Comment { get; set; }
    }
}
