using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("Address")]
    public class Address : DomainEntity<int>
    {
        public Address(int id, int provinceId, int districtId, int wardId, int streetId)
        {
            Id = id;
            ProvinceId = provinceId;
            DistrictId = districtId;
            WardId = wardId;
            StreetId = streetId;
        }

        public int ProvinceId { get; set; }

        public int DistrictId { get; set; }

        public int WardId { get; set; }

        public int StreetId { get; set; }
    }
}