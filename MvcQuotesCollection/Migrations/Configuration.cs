namespace MvcQuotesCollection.Migrations
{
    using MvcQuotesCollection.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcQuotesCollection.Models.QuoteDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcQuotesCollection.Models.QuoteDBContext";
        }

        protected override void Seed(MvcQuotesCollection.Models.QuoteDBContext context)
        {
            context.Quotes.AddOrUpdate(i => i.UserName,
         new Quote
         {
             UserName = "Elae",
             UserAge = 32,
             UserQuote="What does not kill you makes you stronger",
             Rating="5",
             AddedDate=DateTime.Parse("1986-2-23"),

         },

          new Quote
          {
              UserName = "Anna",
              UserAge = 22,
              UserQuote = "What does not kill you makes you stronger",
              Rating ="5",
              AddedDate = DateTime.Parse("1986-2-23"),
          },

          new Quote
          {
              UserName = "Bahare",
              UserAge = 32,
              UserQuote = "What does not kill you makes you stronger",
              Rating ="5",
              AddedDate = DateTime.Parse("1986-2-23"),
          },

        new Quote
        {
            UserName = "Alex",
            UserAge = 36,
            UserQuote = "What does not kill you makes you stronger",
            Rating ="5",
            AddedDate = DateTime.Parse("1986-2-23"),
        }
    );
        }
    }
}
