using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("ProductImages")]
    public class CoursesImage : DomainEntity<int>
    {
        public CoursesImage(int id, int productId, string path, string caption)
        {
            Id = id;
            CoursesId = productId;
            Path = path;
            Caption = caption;
        }

        public int CoursesId { get; set; }

        [ForeignKey("CoursesId")]
        public virtual Courses Courses { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }
    }
}