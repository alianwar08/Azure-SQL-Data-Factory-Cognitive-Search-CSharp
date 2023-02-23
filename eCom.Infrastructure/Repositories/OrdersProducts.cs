using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Infrastructure.Persistance.Repositories
{
    public class OrdersProducts
    {       

        // Foreign key   
        [Display(Name = "Order")]
        [Key]
        [MaxLength(50)]
        public virtual Guid? order_id       { get; set; }

        [ForeignKey("order_id")]
        public virtual Order Order          { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        [Key]
        [MaxLength(50)]
        public virtual Guid? product_id     { get; set; }

        [ForeignKey("product_id")]
        public virtual Product Product      { get; set; }

        [Timestamp]
        public Byte[] RowVersion            { get; set; }

        public bool? IsDeleted              { get; set; }

    }


}
