using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("DichVuImages")]
    public class DichVuImages : DomainEntity<int>
    {
        public int DichVuId { get; set; }

        [ForeignKey("DichVuId")]
        public virtual DichVu DichVu { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }
    }
}