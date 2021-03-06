﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("ShipCode")]
    public class ShipCode : DomainEntity<long>
    {
        public ShipCode()
        {
        }

        public ShipCode(long id, string carriers, DateTime dilivery, decimal collectionFee, decimal total, string zipCode, int idadress)
        {
            Id = id;
            Carriers = carriers;
            DeliveryTime = dilivery;
            CollectionFee = collectionFee;
            Total = total;
            ZipCode = zipCode;
            IdAddress = idadress;
        }

        //Hãng Vận Chuyển
        public string Carriers { get; set; }

        //Thời Gian Vận Chuyển

        public DateTime DeliveryTime { get; set; }

        //Chi Phí Thu Hộ
        public decimal CollectionFee { get; set; }

        //Code Theo Quận
        public string ZipCode { get; set; }

        //Tồng Chi Phí
        public decimal Total { get; set; }

        public int IdAddress { get; set; }
    }
}