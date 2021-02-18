using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach Section 2 Group 1

namespace Project5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    //Books to enter into the database

                    new Book
                    {
                        Isbn = "978 - 0451419439",
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ClassificationCategoryA = "Fiction",
                        ClassificationCategoryB = "Classic",
                        Price = 9.95
                    },

                    new Book
                    {
                        Isbn = "978 - 0743270755",
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Biography",
                        Price = 14.58
                    },
                    new Book
                    {
                        Isbn = "978 - 0553384611",
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Biography",
                        Price = 21.54
                    },

                    new Book
                    {
                        Isbn = "978 - 0812981254",
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Biography",
                        Price = 11.61
                    },

                    new Book
                    {
                        Isbn = " 978 - 0812974492",
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Historical",
                        Price = 13.33
                    },

                    new Book
                    {
                        Isbn = "978 - 0804171281",
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ClassificationCategoryA = "Fiction",
                        ClassificationCategoryB = "Historical Fiction",
                        Price = 15.95
                    },

                    new Book
                    {
                        Isbn = "978 - 1455586691",
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Self - Help",
                        Price = 14.99
                    },

                    new Book
                    {
                        Isbn = "978 - 1455523023",
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Self - Help",
                        Price = 21.66
                    },

                    new Book
                    {
                        Isbn = "978 - 1591847984",
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ClassificationCategoryA = "Non - Fiction",
                        ClassificationCategoryB = "Business",
                        Price = 29.16
                    },

                    new Book
                    {
                        Isbn = "978 - 0553393613",
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ClassificationCategoryA = "Fiction",
                        ClassificationCategoryB = "Thrillers",
                        Price = 15.03
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
