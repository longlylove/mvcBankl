using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date\\Time")]
        [Column(TypeName = "datetime")]
        public DateTime TransactionTimeStamp { get; set; } 

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name="Amount")]
        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }

        [Display(Name = "Deposit Note")]
        [Column(TypeName = "varchar")]
        [StringLength(150)]
        public string DepositNote { get; set; }

        [Required]
        public int CheckingAccountId { get; set; }

        //[Required]
        //public string ApplicationUserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        public virtual CheckingAccount CheckingAccount { get; set; }

        
    }
}