using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;
using Lib.Data.Enums;

namespace Lib.Data.Entities
{
    [Table("DichVuCategory")]
    public class DichVuCategory : DomainEntity<int>
    {
        public DichVuCategory()
        {
            DichVus = new List<DichVu>();
        }

        public DichVuCategory(string name, string description, int? parentId, int? menuId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder, Status status, string seoPageTitle, string seoAlias,
            string seoKeywords, string seoDescription)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            MenuId = menuId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? MenuId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { set; get; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }

        public virtual ICollection<DichVu> DichVus { set; get; }
    }
}