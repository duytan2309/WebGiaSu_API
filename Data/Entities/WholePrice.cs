using Lib.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("WholePrices")]
    public class WholePrice : DomainEntity<int>
    {
        public WholePrice()
        {
        }

        public WholePrice(int id, int productId, int fromQuantity,
        int toQuantity, decimal price)
        {
            Id = id;
            CoursesId = productId;
            FromQuantity = fromQuantity;
            ToQuantity = toQuantity;
            Price = price;
        }

        public int CoursesId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("CoursesId")]
        public virtual Courses Courses { get; set; }
    }
}