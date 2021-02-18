using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach Section 2 Group 1

namespace Project5.Models
{
    public class Book
    {
        //auto-generated key
        [Key, Required]
        public int BookId { get; set; }
        //ISBN (validated using regEx)
        [Required, RegularExpression("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$", ErrorMessage = "Must be a valid ISBN number in format and 10 or 13 digits")]
        public string Isbn { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        //Author name split into first and last
        public string AuthorFirst { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        //This field stores whether the book is fiction or not (is not a repeat of B!)
        [Required]
        public string ClassificationCategoryA {get; set;}
        //This field stores the larger category of the book (thriller, biography, etc. (is not a repeat of A!)
        [Required]
        public string ClassificationCategoryB { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
