using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("TrademarkLogos")]
    public class TrademarkLogos : DomainEntity<int>
    {
        public TrademarkLogos(int id, int trademarkId, string path, string caption, string type)
        {
            Id = id;
            TrademarkId = trademarkId;
            Path = path;
            Caption = caption;
            Type = type;
        }

        public int TrademarkId { get; set; }

        //[ForeignKey("TrademarkLogos")]
        //public virtual ProductTrademark ProductTrademark { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        public string Type { get; set; }
    }
}