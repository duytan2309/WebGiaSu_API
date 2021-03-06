﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("AppUserLogins")]
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
        public AppUserLogin() : base()
        {
        }

        public virtual AppUser AppUser { get; set; }
    }
}