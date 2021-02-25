using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [RegularExpression(@"^(?=:\D*\d){3}(?:(?:\D*\d){10})?$)[\d-]+$",
            ErrorMessage ="ISBN is not in the correct format.")]
        public string ISBN { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        public int Pages { get; set; }
    }
}
