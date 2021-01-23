using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("Footers")]
    public class Footer : DomainEntity<string>
    {
        public Footer(string id, string content)
        {
            Id = id;
            Content = content;
        }

        [Required]
        public string Content { set; get; }
    }
}