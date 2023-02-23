using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCom.Infrastructure.NewFolder
{
    public record Cg_Product
    {
        public string product_id { get; set; }

        public string product_name { get; set; }

        public string price { get; set; }

        public string description { get; set; }

        public string image_url { get; set; }

        public DateTime? date_added { get; set; }

        public string category_id { get; set; }

        public bool? IsDeleted { get; set; }

        public string category_name { get; set; }

    }
}
