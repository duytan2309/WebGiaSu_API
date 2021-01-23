using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("SlideImages")]
    public class SlideImages : DomainEntity<int>
    {
        public SlideImages(int id, int slideId, string path, string caption, string type)
        {
            Id = id;
            SlideId = slideId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int SlideId { get; set; }

        //[ForeignKey("SlideId")]
        //public virtual Slide Slide { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}