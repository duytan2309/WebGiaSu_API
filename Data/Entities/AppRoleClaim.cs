using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("AppRoleClaims")]
    public class AppRoleClaim : IdentityRoleClaim<Guid>
    {
        public AppRoleClaim() : base()
        {
        }
    }
}