namespace TheThreeOwlsWebApp.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using TheThreeOwlsWebApp.Data;
    using TheThreeOwlsWebApp.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var seviceProvider = scopedServices.ServiceProvider;

            var data = scopedServices.ServiceProvider.GetService<ThreeOwlsDbContext>();

            data.Database.Migrate();

            AddDefaultCategories(data);

            AddDefaultContactInfo(data);

            AddAdmin(seviceProvider);

            return app;
        }

        private static void AddAdmin(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<IdentityUser>>();

            Task
                .Run(async () =>
                {
                    const string adminEmail = "admin@tto.com";
                    const string adminPassword = "123456789";

                    var user = new IdentityUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail
                    };

                    await userManager.CreateAsync(user ,adminPassword);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void AddDefaultCategories(ThreeOwlsDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new CourseCategory { Language = "Английски език"},
                new CourseCategory { Language = "Немски език"},
                new CourseCategory { Language = "Руски език"},
                new CourseCategory { Language = "Литература"},
                new CourseCategory { Language = "Математика"},
            });

            data.SaveChanges();
        }

        private static void AddDefaultContactInfo(ThreeOwlsDbContext data)
        {
            if (data.Schools.Any())
            {
                return;
            }

            data.Schools.Add(new School
            {
                Name = "Образователен център Трите сови",
                Address = "ул. Ангел Димитров 28А 8016 Burgas",
                Telephone = "089 596 5764",
                Email = "tritesovi@gmail.com",
                FacebookPath
                    = "https://www.facebook.com/%D0%9E%D0%B1%D1%80%D0%B0%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D0%B5%D0%BB%D0%B5%D0%BD-%D1%86%D0%B5%D0%BD%D1%82%D1%8A%D1%80-%D0%A2%D1%80%D0%B8%D1%82%D0%B5-%D1%81%D0%BE%D0%B2%D0%B8-352266128437687"
            });

            data.SaveChanges();
        }
    }
}