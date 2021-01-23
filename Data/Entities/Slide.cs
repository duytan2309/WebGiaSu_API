using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>
    {
        public Slide(int id, string name, string description, string url, string image, int displayOrder, bool status, string content, int groupOrder
         )
        {
            Id = id;
            Name = name;
            Description = description;
            Url = url;
            Image = image;
            DisplayOrder = displayOrder;
            Status = status;
            Content = content;
            GroupOrder = groupOrder;
        }

        [StringLength(250)]
        //[Required]
        public string Name { set; get; }

        [StringLength(250)]
        public string Description { set; get; }

        [StringLength(250)]
        //[Required]
        public string Image { set; get; }

        [StringLength(250)]
        public string Url { set; get; }

        public int DisplayOrder { set; get; }

        public bool Status { set; get; }

        public string Content { set; get; }

        [StringLength(25)]
        //[Required]
        public int GroupOrder { get; set; }
    }
}