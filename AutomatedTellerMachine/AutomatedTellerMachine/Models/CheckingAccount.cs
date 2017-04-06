using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6)]
        [Column(TypeName = "VARCHAR")]
        //[RegularExpression(@"\d{6,10}", ErrorMessage = "Account number must be between 6 and 10 digits")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public string Name => $"{FirstName} {LastName}";

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } 
    }
}