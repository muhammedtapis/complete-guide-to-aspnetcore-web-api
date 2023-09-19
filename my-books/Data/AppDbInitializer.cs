using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {

        //eğer database boşsa database veri eklemek için kullanılacak bir method oluşturacağız.

        public static void Seed(IApplicationBuilder applicationBuilder) {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>(); //appdbcontexti burdaki contexte atıyoruz.

                if (!context.Books.Any()) 
                { 
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10), // 10 gün önce.
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now

                    }, 
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "1st Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now

                    }

                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
