using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;
using Lib.Data.Enums;

namespace Lib.Data.Entities
{
    [Table("Pages")]
    public class Page : DomainEntity<int>
    {
        public Page()
        {
        }

        public Page(int id, string name,
            string content, Status status, int? homeOrder, int sortOrder, string groupAlias, string seoAlias, string alias, int idPages)
        {
            Id = id;
            Name = name;
            Content = content;
            Status = status;
            HomeOrder = homeOrder;
            SortOrder = sortOrder;
            GroupAlias = groupAlias;
            SeoAlias = seoAlias;
            Alias = alias;
            IdPages = idPages;
        }

        //[Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public string Content { set; get; }
        public Status Status { set; get; }

        public int? HomeOrder { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }

        [StringLength(25)]
        //[Required]
        public string GroupAlias { get; set; }

        public string SeoAlias { get; set; }

        public string Alias { get; set; }

        public int IdPages { get; set; }
    }
}