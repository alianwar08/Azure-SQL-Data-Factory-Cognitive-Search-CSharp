using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Infrastructure.Persistance.Repositories
{
    public class Order
    {
        [Key]
        [MaxLength(50)]
        public Guid     order_id            { get; set; }
        public DateTime  order_date         { get; set; }

        [MaxLength(150)]
        public string?  customer_name       { get; set; }

        [Timestamp]
        public Byte[] RowVersion            { get; set; }

        public bool? IsDeleted              { get; set; }

    }


}
