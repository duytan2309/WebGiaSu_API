using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;
using Lib.Data.Enums;

namespace Lib.Data.Entities
{
    [Table("Questions")]
    public class Questions : DomainEntity<int>
    {
        public Questions()
        {
        }

        public Questions(string name, string thumbnailImage,
           string description, string content, Status status, string seoPageTitle,
           string seoAlias, string seoMetaKeyword,
           string seoMetaDescription, Guid idUser, int parentId, string typePage, int datailPage)
        {
            Name = name;
            Image = thumbnailImage;
            Description = description;
            Content = content;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            IdUser = idUser;
            ParentId = parentId;
        }

        public Questions(int id, string name, string thumbnailImage,
             string description, string content, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription, Guid idUser, int parentId, int categoryId)
        {
            Id = id;
            Name = name;
            Image = thumbnailImage;
            Description = description;
            Content = content;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            IdUser = idUser;
            ParentId = parentId;
            CategoryId = categoryId;
        }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public string Content { set; get; }

        public int? ViewCount { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }

        [MaxLength(256)]
        public string SeoPageTitle { set; get; }

        [MaxLength(256)]
        public string SeoAlias { set; get; }

        [MaxLength(256)]
        public string SeoKeywords { set; get; }

        [MaxLength(256)]
        public string SeoDescription { set; get; }

        public Guid IdUser { set; get; }

        public int ParentId { set; get; }

        public int CategoryId { set; get; }

        [ForeignKey("CategoryId")]
        public virtual QuestionCategories QuestionCategories { set; get; }
    }
}