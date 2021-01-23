using Lib.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("TrademarkImages")]
    public class TrademarkImages : DomainEntity<int>
    {
        public TrademarkImages(int id, int trademarkId, string path, string caption, string type)
        {
            Id = id;
            TrademarkId = trademarkId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int TrademarkId { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}