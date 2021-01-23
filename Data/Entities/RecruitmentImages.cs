using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("RecruitmentImages")]
    public class RecruitmentImages : DomainEntity<int>
    {
        public RecruitmentImages(int id, int recruitmentId, string path, string caption, string type)
        {
            Id = id;
            RecruitmentId = recruitmentId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int RecruitmentId { get; set; }

        [ForeignKey("RecruitmentId")]
        public virtual Recruitment Recruitment { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}