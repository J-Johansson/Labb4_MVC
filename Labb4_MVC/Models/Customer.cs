using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_MVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string CustomerName { get; set; }

        public long Phone { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
