using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Domain.Entities
{
    [Table("OrdersDetails")]
    public class OrdersDetails
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
        public int OrdersDetailsID { get; set; }
        public int OrdersID { get; set; }
        public int ProductsID { get; set; }
        public int ProductsInfoID { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyShipped { get; set; }
        public int QtyInvoiced { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustAdrsID { get; set; }
        public string Comment { get; set; }

        [ForeignKey("OrdersID")]
        public virtual Orders Orders { get; set; }

        [ForeignKey("ProductsID")]
        public virtual Products Product { get; set; }
    }
}
