using Lib.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("Sizes")]
    public class Size : DomainEntity<int>
    {
        public Size(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [StringLength(250)]
        public string Name
        {
            get; set;
        }
    }
}