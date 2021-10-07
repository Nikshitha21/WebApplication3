using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UserDetails
    {
        [Key]
        public int customerID { get; set; }
        public long AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string GuardianType { get; set; }
        [Required]
        public string GuardianName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Citizenship { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        [Required]
        public string AccType { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string CitizenStatus { get; set; }
        [Required]
        public int DepositAmmount { get; set; }
        [Required]
        public string proofType { get; set; }
        [Required]
        public string DocNumber { get; set; }
        [Required]
        public string HolderName { get; set; }
        [Required]
        public string HolderAcctNumber { get; set; }
        [Required]
        public string HolderAddress { get; set; }

    }
    
}
