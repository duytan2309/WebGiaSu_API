using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    public class CoursesTag : DomainEntity<int>
    {
        public CoursesTag()
        { }

        public int CoursesId { get; set; }

        [StringLength(50)]
        public string TagId { set; get; }

        [ForeignKey("CoursesId")]
        public virtual Courses Courses { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}