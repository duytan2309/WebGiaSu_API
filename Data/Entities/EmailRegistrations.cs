using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;
namespace Lib.Data.Entities
{
    [Table("EmailRegistrations")]
    public class EmailRegistrations : DomainEntity<int>
    {
        public EmailRegistrations()
        {
        }

        public EmailRegistrations(int id, string email, DateTime dateCreated)
        {
            Id = id;
            Email = email;
            DateCreated = dateCreated;
        }

        [StringLength(50)]
        [Required]
        public string Email { set; get; }

        public DateTime DateCreated { set; get; }
    }
}