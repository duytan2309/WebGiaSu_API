using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("Payment")]
    public class Payment : DomainEntity<int>
    {
        public Payment()
        {
        }

        public Payment(int id, int typePay, string accountNumber,
            DateTime expirationDate, int verificationNumber, Guid userId)
        {
            Id = id;
            TypePay = typePay;
            AccountNumber = accountNumber;
            ExpirationDate = expirationDate;
            VerificationNumber = verificationNumber;
            UserId = userId;
        }

        public int TypePay { set; get; }

        [MaxLength(20)]
        [Required]
        public string AccountNumber { set; get; }

        public DateTime ExpirationDate { set; get; }

        public int VerificationNumber { set; get; }
        public Guid UserId { set; get; }
    }
}