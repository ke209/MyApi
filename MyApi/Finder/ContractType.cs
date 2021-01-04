using System;
using System.Collections.Generic;
using System.Text;

namespace MyApi.Finder
{
    public class ContractType
    {
        public List<ApiContractType> ApiTypes { get; set; }
        public List<MyApiSiteType> SiteTypes { get; set; }
    }
}
