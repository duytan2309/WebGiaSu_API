
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.Enums;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("Functions")]
    public class Function : DomainEntity<string>
    {
        public Function()
        {
        }

        public Function(string name, string url, string parentId, string iconCss, int sortOrder, int homeOrder, string groupAlias)
        {
            this.Name = name;
            this.URL = url;
            this.ParentId = parentId;
            this.IconCss = iconCss;
            this.SortOrder = sortOrder;
            this.HomeOrder = homeOrder;
            this.Status = Status.Active;
            this.GroupAlias = groupAlias;
        }

        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        [StringLength(250)]
        public string URL { set; get; }

        [StringLength(128)]
        public string ParentId { set; get; }

        public string IconCss { get; set; }
        public int SortOrder { set; get; }

        public int? HomeOrder { get; set; }

        public Status Status { set; get; }

        public string GroupAlias { get; set; }
    }
}