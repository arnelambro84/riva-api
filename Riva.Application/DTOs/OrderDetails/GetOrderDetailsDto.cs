using Riva.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Application.DTOs.OrderDetails
{
    public class GetOrderDetailsDto
    {
        public int OrderDetailsID { get; set; }
        public int OrdersID { get; set; }
        public int ProductsID { get; set; }
        public int ProductsInfoID { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyShipped { get; set; }
        public int QtyInvoiced { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustAddrsID { get; set; }
        public string Comment { get; set; }

        public ProductDetailsDto Product { get; set; }
    }
}
