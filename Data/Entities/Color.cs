using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("Colors")]
    public class Color : DomainEntity<int>
    {
        public Color()
        {
        }

        public Color(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public Color(string name, string code)
        {
            Name = name;
            Code = code;
        }

        [StringLength(250)]
        public string Name
        {
            get; set;
        }

        [StringLength(250)]
        public string Code { get; set; }
    }
}