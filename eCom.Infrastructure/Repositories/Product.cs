using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Infrastructure.Persistance.Repositories
{
    public class Product
    {
        [Key]
        [MaxLength(50)]
        public Guid     product_id                { get; set; }

        [MaxLength(150)]
        public string?  product_name              { get; set; }
        //public Guid?  category_id               { get; set; }
        public decimal?  price                     { get; set; }


        [MaxLength(250)] 
        public string?  description               { get; set; }
        [MaxLength(500)]
        public string?    image_url               { get; set; }
        public DateTime      date_added           { get; set; }

        // Foreign key   
        [Display(Name = "Category")]
        public virtual Guid? category_id         { get; set; }

        [ForeignKey("category_id")]
        public virtual Category Category         { get; set; }

        [Timestamp]
        public Byte[] RowVersion                 { get; set; }

        public bool? IsDeleted                   { get; set; }
    }


}
