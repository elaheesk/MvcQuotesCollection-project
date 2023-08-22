using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Xml.Linq;

namespace MvcQuotesCollection.Models

{
    public class Quote
    {
        public int ID { get; set; }




        [Display(Name = "Name"), Required, StringLength(10, MinimumLength = 2)]

        public string UserName { get; set; }



       [Display(Name = "Age")]
        public int UserAge { get; set; }




        [Display(Name = "Quote"), Required, StringLength(100, MinimumLength = 15)]
        public string UserQuote { get; set; }





        [Required, StringLength(5)]
        public string Rating { get; set; }






        [Display(Name = "Date"), DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }

    public class QuoteDBContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
    }
}