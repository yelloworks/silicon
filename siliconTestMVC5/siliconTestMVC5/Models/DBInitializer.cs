using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using siliconTestMVC5.Models.Entities;

namespace siliconTestMVC5.Models
{
    public class DBInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            
            //Creating Demo Users
            CreateAndSetRole(context, new ApplicationUser { UserName = "StockAdmin", Email = "demo@mail.ru" }, new IdentityRole { Name = "Admin" });
            CreateAndSetRole(context, new ApplicationUser { UserName = "StockUser", Email = "demo@mail.ru" }, new IdentityRole { Name = "User" });
            CreateAndSetRole( context, new ApplicationUser { UserName = "StockGuest", Email = "demo@mail.ru" }, new IdentityRole{ Name="Guest" });
            //           Demo Password, same for all
            //string demoPassword = "Qweasd111!";


            var categories = new List<Category>
            {
                new Category {Name = "Посуда", Description = "Some Посуда"},
                new Category {Name = "Продукты", Description = "Some Еда"},
                new Category {Name = "Электроника", Description = "Это категория электроника, тут много всяких товаров. Длинное описание категории, много много символов, но нужно еще больше, нужно больше ста пятидесяти или ничего не будет видно"},
                new Category {Name = "Здоровье", Description = "Some Здоровье"},
                new Category {Name = "Сувениры", Description = "Some Сувениры"},
                new Category {Name = "Стирка", Description = "Some Стирка"},
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            byte[] tmpImage = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/images/plate.png"));
            

            var products = new List<Product>
            {
                new Product { Name = "Тарелка", CurrentCategoryName = "Посуда", Description = "Это же тарелка", Price = 1, Count = 1, Image = tmpImage},
                new Product { Name = "Чашка", CurrentCategoryName = "Посуда", Description = "Это же чашка", Price = 1, Count = 2},
                new Product { Name = "Блюдце", CurrentCategoryName = "Посуда", Description = "Это же Блюдце", Price = 1, Count = 1},
                new Product { Name = "Ложка", CurrentCategoryName = "Посуда", Description = "Это же Ложка", Price = 1, Count = 2},
                new Product { Name = "Вилка", CurrentCategoryName = "Посуда", Description = "Это же Вилка", Price = 1, Count = 1},
                new Product { Name = "Сито", CurrentCategoryName = "Посуда", Description = "Это же Сито", Price = 1, Count = 2},
                new Product { Name = "Этажерка", CurrentCategoryName = "Посуда", Description = "Это же Этажерка", Price = 1, Count = 1},
                new Product { Name = "Ваза", CurrentCategoryName = "Посуда", Description = "Это же Ваза", Price = 1, Count = 2},
                new Product { Name = "Нож разделочный", CurrentCategoryName = "Посуда", Description = "Это же Нож", Price = 1, Count = 1},
                new Product { Name = "Нож кухонный", CurrentCategoryName = "Посуда", Description = "Это же Нож", Price = 1, Count = 2},
                new Product { Name = "Нож для овощей", CurrentCategoryName = "Посуда", Description = "Это же Нож", Price = 1, Count = 1},
                new Product { Name = "Кастрюля", CurrentCategoryName = "Посуда", Description = "Это же Кастрюля", Price = 1, Count = 2},
                new Product { Name = "Блинница", CurrentCategoryName = "Посуда", Description = "Это же Блинница", Price = 1, Count = 1},
                new Product { Name = "Сковородка", CurrentCategoryName = "Посуда", Description = "Это же Сковородка", Price = 1, Count = 2},
                new Product { Name = "Скороварка", CurrentCategoryName = "Посуда", Description = "Это же Скороварка", Price = 1, Count = 1},
                new Product { Name = "Банкетница", CurrentCategoryName = "Посуда", Description = "Это же Банкетница", Price = 1, Count = 2},
                new Product { Name = "Подстаканник", CurrentCategoryName = "Посуда", Description = "Это же Подстаканник", Price = 1, Count = 1},
                new Product { Name = "Бокал", CurrentCategoryName = "Посуда", Description = "Это же Бокал", Price = 1, Count = 2},
                new Product { Name = "Рюмка", CurrentCategoryName = "Посуда", Description = "Это же Рюмка", Price = 1, Count = 1},
                new Product { Name = "Фужер", CurrentCategoryName = "Посуда", Description = "Это же Фужер", Price = 1, Count = 2},
                new Product { Name = "Доска", CurrentCategoryName = "Посуда", Description = "Это же Доска", Price = 1, Count = 1},
                new Product { Name = "Котлетница", CurrentCategoryName = "Посуда", Description = "Это же Котлетница", Price = 1, Count = 2},
                new Product { Name = "Масленка", CurrentCategoryName = "Посуда", Description = "Это же Масленка", Price = 1, Count = 1},
                new Product { Name = "СПРАЯ", CurrentCategoryName = "Посуда", Description = "Это же СПРАЯ", Price = 1, Count = 2},
                new Product { Name = "Яблоко", CurrentCategoryName = "Продукты", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Персик", CurrentCategoryName = "Продукты", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Апельсин", CurrentCategoryName = "Продукты", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Котлета", CurrentCategoryName = "Продукты", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Рыба", CurrentCategoryName = "Продукты", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Плойка", CurrentCategoryName = "Электроника", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Витрум", CurrentCategoryName = "Здоровье", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Брелок", CurrentCategoryName = "Сувениры", Description = "Это же Яблоко", Price = 1, Count = 2},
                new Product { Name = "Порошок", CurrentCategoryName = "Стирка", Description = "Это же Яблоко", Price = 1, Count = 2},

            };

            context.Products.AddRange(products);
            context.SaveChanges();

           // var count = context.Categories.FirstOrDefault(p => p.Name == "Посуда").Products.Count;

            base.Seed(context);
        }
        

        
        private void CreateAndSetRole(ApplicationDbContext context, ApplicationUser user, IdentityRole role)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(role);

            //Demo Password, same for all
            string demoPassword = "Qweasd111!";

            var result = userManager.Create(user, demoPassword);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, role.Name);
            }
        }

        
    }
}