using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("SupportImages")]
    public class SupportImages : DomainEntity<int>
    {
        public SupportImages(int id, int supportId, string path, string caption, string type)
        {
            Id = id;
            SupportId = supportId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int SupportId { get; set; }

        [ForeignKey("SupportId")]
        public virtual Support Support { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}