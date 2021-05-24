using System;
using System.Linq;
using Dot_net_5_practice.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Dot_net_5_practice.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (context != null && !context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                        {
                            Title = "1st book title",
                            Description = "hello this is my first programing book",
                            Author = "Arham",
                            CoverUrl = "http....",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            DateAdded = DateTime.Now,
                            Rate = 4,
                            Genre = "hello",
                        },
                        new Book()
                        {
                            Title = "2nd book title",
                            Description = "hello this is my second programing book",
                            Author = "Ar",
                            CoverUrl = "https....",
                            IsRead = false,
                            DateRead = DateTime.Now.AddDays(-10),
                            DateAdded = DateTime.Now,
                            Rate = 20,
                            Genre = "Laravel",
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}