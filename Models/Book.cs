using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project5.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ClassificationCategory {get; set;}
        public double Price { get; set; }
    }
}
