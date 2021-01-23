using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("BlogImages")]
    public class BlogImages : DomainEntity<int>
    {
        public BlogImages(int id, int blogId, string path, string caption, string type)
        {
            Id = id;
            BlogId = blogId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int BlogId { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}