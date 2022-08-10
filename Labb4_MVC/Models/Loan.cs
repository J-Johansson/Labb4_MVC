using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_MVC.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [ForeignKey("Books")]
        public int FkBookId { get; set; }
        public Book Books { get; set; }

        [ForeignKey("Customers")]
        public int FkCustomerId { get; set; }
        public Customer Customers { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
