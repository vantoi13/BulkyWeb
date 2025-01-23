using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BulkyWeb.Models;

namespace BulkyWeb.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Thêm 10 bản ghi vào bảng Categories
                if (!context.Categorys.Any())
                {
                    context.Categorys.AddRange(
                        new Category { Name = "Fiction", DisplayOrder = 1 },
                        new Category { Name = "Non-Fiction", DisplayOrder = 2 },
                        new Category { Name = "Science Fiction", DisplayOrder = 3 },
                        new Category { Name = "Mystery", DisplayOrder = 4 },
                        new Category { Name = "Biography", DisplayOrder = 5 },
                        new Category { Name = "Self-Help", DisplayOrder = 6 },
                        new Category { Name = "Fantasy", DisplayOrder = 7 },
                        new Category { Name = "Romance", DisplayOrder = 8 },
                        new Category { Name = "Thriller", DisplayOrder = 9 },
                        new Category { Name = "Children's Books", DisplayOrder = 10 }
                    );
                    context.SaveChanges();
                }

                // Thêm 10 bản ghi vào bảng Products
                if (!context.Products.Any())
                {
                    var categories = context.Categorys.ToList();
                    context.Products.AddRange(
                        new Product
                        {
                            CategoryId = categories[0].Id,
                            Title = "The Great Gatsby",
                            Description = "A classic novel by F. Scott Fitzgerald",
                            ISBN = "9780743273565",
                            Author = "F. Scott Fitzgerald",
                            ListPrice = 20.00,
                            Price = 18.00,
                            Price50 = 15.00,
                            Price100 = 12.00,
                            ImagePath = "images/gatsby.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[1].Id,
                            Title = "Sapiens: A Brief History of Humankind",
                            Description = "A thought-provoking book by Yuval Noah Harari",
                            ISBN = "9780062316097",
                            Author = "Yuval Noah Harari",
                            ListPrice = 25.00,
                            Price = 22.50,
                            Price50 = 20.00,
                            Price100 = 18.00,
                            ImagePath = "images/sapiens.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[2].Id,
                            Title = "Dune",
                            Description = "A science fiction masterpiece by Frank Herbert",
                            ISBN = "9780441013593",
                            Author = "Frank Herbert",
                            ListPrice = 30.00,
                            Price = 27.00,
                            Price50 = 24.00,
                            Price100 = 21.00,
                            ImagePath = "images/dune.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[3].Id,
                            Title = "The Hound of the Baskervilles",
                            Description = "A classic mystery novel by Arthur Conan Doyle",
                            ISBN = "9780451528018",
                            Author = "Arthur Conan Doyle",
                            ListPrice = 15.00,
                            Price = 13.50,
                            Price50 = 12.00,
                            Price100 = 10.00,
                            ImagePath = "images/hound.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[4].Id,
                            Title = "Steve Jobs",
                            Description = "A biography by Walter Isaacson",
                            ISBN = "9781451648539",
                            Author = "Walter Isaacson",
                            ListPrice = 28.00,
                            Price = 25.00,
                            Price50 = 22.00,
                            Price100 = 20.00,
                            ImagePath = "images/steve_jobs.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[5].Id,
                            Title = "The Power of Habit",
                            Description = "An inspiring book by Charles Duhigg",
                            ISBN = "9780812981605",
                            Author = "Charles Duhigg",
                            ListPrice = 18.00,
                            Price = 16.00,
                            Price50 = 14.00,
                            Price100 = 12.00,
                            ImagePath = "images/habit.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[6].Id,
                            Title = "Harry Potter and the Sorcerer's Stone",
                            Description = "A fantasy novel by J.K. Rowling",
                            ISBN = "9780590353427",
                            Author = "J.K. Rowling",
                            ListPrice = 25.00,
                            Price = 22.50,
                            Price50 = 20.00,
                            Price100 = 18.00,
                            ImagePath = "images/harry_potter.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[7].Id,
                            Title = "Pride and Prejudice",
                            Description = "A romance novel by Jane Austen",
                            ISBN = "9781503290563",
                            Author = "Jane Austen",
                            ListPrice = 15.00,
                            Price = 13.50,
                            Price50 = 12.00,
                            Price100 = 10.00,
                            ImagePath = "images/pride_and_prejudice.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[8].Id,
                            Title = "The Girl with the Dragon Tattoo",
                            Description = "A thrilling novel by Stieg Larsson",
                            ISBN = "9780307949486",
                            Author = "Stieg Larsson",
                            ListPrice = 20.00,
                            Price = 18.00,
                            Price50 = 16.00,
                            Price100 = 14.00,
                            ImagePath = "images/dragon_tattoo.jpg"
                        },
                        new Product
                        {
                            CategoryId = categories[9].Id,
                            Title = "Charlotte's Web",
                            Description = "A children's classic by E.B. White",
                            ISBN = "9780061124952",
                            Author = "E.B. White",
                            ListPrice = 10.00,
                            Price = 9.00,
                            Price50 = 8.00,
                            Price100 = 7.00,
                            ImagePath = "images/charlottes_web.jpg"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
