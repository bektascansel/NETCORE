using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {

                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        // Id=1,
                        Title = "lean Startup",
                        GenreId = 1, //personal grouth
                        PageCount = 200,


                    },

                   new Book
                   {
                       // Id=2,
                       Title = "herland",
                       GenreId = 2, //personal grouth
                       PageCount = 250,


                   },

                   new Book
                   {
                       // Id=3,
                       Title = "dune",
                       GenreId = 3, //personal grouth
                       PageCount = 500,


                   }
                );

                context.SaveChanges();



















            }

        }



    }
}