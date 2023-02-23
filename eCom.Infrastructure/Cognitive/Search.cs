using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using eCom.Infrastructure.NewFolder;
using eCom.Infrastructure.Persistance.Repositories;

namespace eCom.Infrastructure.Cognitive
{
    public class Search
    {

        static string serviceName = "aa-cogsrv-ecom";
        static string apiKey = "<Cognitive Service API Key>";
        static string indexName = "azuresql-index";

        public static SearchResults<Cg_Product> FindProducts(PagingInfo pageInfo, string keywords)
        {
            //Create a SearchIndexClient to send  index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

            //Create a SearchClient to load and query documents
            SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);


            var searchOptions = new SearchOptions()
            {
                SearchMode = SearchMode.All,
                Size = pageInfo.PageSize,
                Skip = pageInfo.PageSize * pageInfo.PageNumber,
                IncludeTotalCount = true,

            };

            var res = srchclient.Search<Cg_Product>(keywords, searchOptions);

            return res.Value;

        }

    }


    public class PagingInfo
    {
        public PagingInfo() {
            PageNumber = 0;
            PageSize = 10;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
