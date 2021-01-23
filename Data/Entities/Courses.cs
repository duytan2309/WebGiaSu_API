using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("Courses")]
    public partial class Courses
    {
        public Courses()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Code { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string Content { get; set; }
        public string VAT { get; set; }
        public int Status { get; set; }
    }
}