using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Application.DTOs.Orders
{
    public class GetOrdersReportDto
    {
        public int OrdersId { get; set; }
        public string POInternal { get; set; }
        public string POExternal { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string ProductName { get; set; }
        public int QtyOrdered { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DueDate { get; set; }


    }
}
