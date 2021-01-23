using Lib.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("Routes")]
    public class Routes : DomainEntity<int>
    {
        public Routes(int id, string name, string seoPages, string seoAlias, string seoIdPages, string seoNameAlias
       )
        {
            Id = id;
            Name = name;
            SeoPages = seoPages;
            SeoAlias = seoAlias;
            SeoIdPages = seoIdPages;
            SeoNameAlias = seoNameAlias;
        }

        [StringLength(250)]
        public string Name { set; get; }

        [StringLength(50)]
        public string SeoPages { set; get; }

        public string SeoAlias { set; get; }
        public string SeoIdPages { set; get; }
        public string SeoNameAlias { set; get; }
    }
}