using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using Lib.Data.Enums;

namespace Lib.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser() : base()
        {
            AppUserRoles = new HashSet<AppUserRole>();
            AppUserClaims = new HashSet<AppUserClaim>();
            AppUserLogins = new HashSet<AppUserLogin>();
            AppUserActions = new HashSet<AppUserActions>();
        }

        public AppUser(string username) : base(username)
        {
            UserName = username;
        }

        public AppUser(string userName, string fullName,
            string email, string phoneNumber, string avatar, Status status)
        {
            this.UserName = userName;
            this.FullName = fullName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Avatar = avatar;
            this.Status = status;
        }

        public AppUser(Guid id, string fullName, string userName,
            string email, string phoneNumber, string avatar, Status status, DateTime? birthday, string address)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Status = status;
            BirthDay = birthday;
            Address = address;
        }

        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public string Address { get; set; }

        public virtual ICollection<AppUserClaim> AppUserClaims { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }

        public virtual ICollection<AppUserLogin> AppUserLogins { get; set; }
        public virtual ICollection<AppUserActions> AppUserActions { get; set; }
    }
}