using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("AppUserRoles")]
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUserRole() : base()
        {
        }

        //public AppUserRole(/*string discriminator*/) : base()
        //{
        //    //Discriminator = discriminator;
        //}

        //[StringLength(128)]
        //public string Discriminator { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { set; get; }

        [ForeignKey("RoleId")]
        public Guid RoleId { set; get; }

        public virtual AppRole AppRoles { get; set; }

        public virtual AppUser AppUsers { get; set; }
    }
}