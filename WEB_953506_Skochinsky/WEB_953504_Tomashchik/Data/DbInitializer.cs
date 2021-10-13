using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEB_953506_Skochinsky.Data;
using WEB_953506_Skochinsky.Entities;

namespace WEB_953506_Skochinsky.Data
{
    public class DbInitializer
    {
        public DbInitializer()
        {
        }

        public static async Task Seed(ApplicationDbContext context,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager)
        {// создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin }
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");

            }
            //проверка наличия групп объектов
            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                     new DishGroup {GroupName="Пиццы"},
                     new DishGroup {GroupName="Салаты"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                 new Dish {DishName="Пицца с копчёными колбасками", Description="Вкусно", Calories =200, DishGroupId=1, Image="pizza1.jpg" },
                 new Dish {DishName="Пицца с прошутто и рукколой", Description="Очень Вкусно", Calories =200, DishGroupId=1, Image="pizza2.jpg" },
                 new Dish {DishName="Пицца \"Флорентийская\"", Description="Невероятно вкусно", Calories =200, DishGroupId=1, Image="pizza3.jpg" },
                 new Dish {DishName="Пицца \n \"Римская\"", Description="Неплохо", Calories =200, DishGroupId=1, Image="pizza4.jpg" },
                 new Dish {DishName="Греческий с бальзамической заправкой", Description="Хороший салат", Calories =200, DishGroupId=2, Image="salat.jpg" },
                });
                await context.SaveChangesAsync();
            }

        }
    }
}