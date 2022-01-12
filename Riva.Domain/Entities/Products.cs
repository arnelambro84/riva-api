using Riva.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Domain.Entities
{
    [Table("Products")]
    public class Products : AuditableBaseEntity
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
        public int ProductsID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string CustomerSKU { get; set; }
        public int ProductsTypeID { get; set; }
        public string ProductDesc { get; set; }
        public int CustomerCode { get; set; }
        public string CommentBox { get; set; }
        public int Status { get; set; }
        public int? UOM { get; set; }
        public string PicPath { get; set; }
        public int JewelryType { get; set; }
    }
}
