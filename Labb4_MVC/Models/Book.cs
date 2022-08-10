using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_MVC.Models
{
    public class Book
    {
        public int BookId { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Description { get; set; }
        public int Pages { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }
}
