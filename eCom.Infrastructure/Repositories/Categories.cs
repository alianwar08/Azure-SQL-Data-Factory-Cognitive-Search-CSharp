using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Infrastructure.Persistance.Repositories
{
    public class Category
    {
        public Category(){}

        [Key]
        [MaxLength(50)]
        public Guid   category_id       { get; set; }

        [MaxLength(150)]
        public string category_name     { get; set; }

        [Timestamp]
        public Byte[] RowVersion        { get; set; }

        public bool? IsDeleted          { get; set; }


    }


}
