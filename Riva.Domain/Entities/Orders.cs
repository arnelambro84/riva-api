using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Domain.Entities
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
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

        public virtual ICollection<OrdersDetails> OrderDetails { get; set; }
    }
}
