using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("PolicyImages")]
    public class PolicyImages : DomainEntity<int>
    {
        public PolicyImages(int id, int policyId, string path, string caption, string type)
        {
            Id = id;
            PolicyId = policyId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public virtual Policies Policy { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}