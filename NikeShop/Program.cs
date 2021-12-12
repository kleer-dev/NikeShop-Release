using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Nike nike1 = new Nike
            {
                Name = "Nike Air Jordan 1",
                Name2 = "Retro High OG Shattered Backboard",
                Price = 210,
                Description = "The Air Jordan 1 Retro High OG Shattered Backboard Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-first.png"
            };

            Nike nike2 = new Nike
            {
                Name = "Nike Air Jordan 1 ",
                Name2 = "Retro High OG Bred Toe",
                Price = 180,
                Description = "The Air Jordan 1 Retro High OG Bred Toe Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-sec.png"
            };

            Nike nike3 = new Nike
            {
                Name = "Nike Air Jordan 1 ",
                Name2 = "Mid Royal White",
                Price = 220,
                Description = "The Air Jordan 1 Mid Royal White Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-third.png"
            };

            Nike nike4 = new Nike
            {
                Name = "Nike Air Jordan 1",
                Name2 = "Retro Mid Pine Green",
                Price = 200,
                Description = "The Air Jordan 1 Retro Mid Pine Green Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-fourth.png"
            };

            Nike nike5 = new Nike
            {
                Name = "Nike Air Max TN Plus",
                Name2 = "Colores Agresivos",
                Price = 301,
                Description = "The Air Max TN Plus Colores Agresivos" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/colores-agr.png"
            };

            Nike nike6 = new Nike
            {
                Name = "Nike Air Max TN Plus",
                Name2 = "Farfetch",
                Price = 301,
                Description = "The Air Max TN Plus Farfetch" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/farfetch.png"
            };

            Nike nike7 = new Nike
            {
                Name = "Nike Air Force 1",
                Name2 = "All White",
                Price = 301,
                Description = "The Air Force 1 All White" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/allwhite.png"
            };

            Nike nike8 = new Nike
            {
                Name = "Nike Air Jordan 1",
                Name2 = "Hi FlyEase",
                Price = 230,
                Description = "The Air Jordan 1 Hi FlyEase" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/hifly.png"
            };

            ApplicationContext.db.Nikes.AddRange(nike1, nike2, nike3, nike4, nike5,
                nike6, nike7, nike8);

            NewNike mainPage1 = new NewNike
            {
                Name = "Nike Air Jordan 1",
                Name2 = "Retro High OG Shattered Backboard",
                Price = 210,
                Description = "The Air Jordan 1 Retro High OG Shattered Backboard Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-first.png"
            };

            NewNike mainPage2 = new NewNike
            {
                Name = "Nike Air Jordan 1 ",
                Name2 = "Retro High OG Bred Toe",
                Price = 180,
                Description = "The Air Jordan 1 Retro High OG Bred Toe Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-sec.png"
            };

            NewNike mainPage3 = new NewNike
            {
                Name = "Nike Air Jordan 1 ",
                Name2 = "Mid Royal White",
                Price = 220,
                Description = "The Air Jordan 1 Mid Royal White Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-third.png"
            };

            NewNike mainPage4 = new NewNike
            {
                Name = "Nike Air Jordan 1",
                Name2 = "Retro Mid Pine Green",
                Price = 200,
                Description = "The Air Jordan 1 Retro Mid Pine Green Shoe" +
                " is inspired by the first AJ1, offering fans of Jordan retros a chance to follow" +
                " in the footsteps of greatness. ",
                Path = "/Pictures/nike-fourth.png"
            };

            ApplicationContext.db.AddRange(mainPage1, mainPage2, mainPage3, mainPage4);

            ApplicationContext.db.SaveChanges();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
