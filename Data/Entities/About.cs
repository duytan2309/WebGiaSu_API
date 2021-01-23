using Lib.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{
    [Table("About")]
    public class About : DomainEntity<string>
    {
        public About()
        {
        }

        public About(string id, string name, string phone, string email,
            string website, string address, string other, double? longtitude, double? latitude, int status, string description)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Website = website;
            Address = address;
            Other = other;
            Lng = longtitude;
            Lat = latitude;
            Status = status;
            Description = description;
        }

        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(50)]
        public string Phone { set; get; }

        [StringLength(250)]
        public string Email { set; get; }

        [StringLength(250)]
        public string Website { set; get; }

        [StringLength(250)]
        public string Address { set; get; }

        public string Other { set; get; }

        public double? Lat { set; get; }

        public double? Lng { set; get; }

        public int Status { set; get; }

        public string Description { set; get; }
    }
}