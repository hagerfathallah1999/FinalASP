using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalASP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //
            builder.Services.AddDbContext<CloudKitchenContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("G"))
            );
            //
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
               
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);

            });
            //
            builder.Services.AddScoped<IDeliveryCompanyRepository, DeliveryCompanyRepository>();
            builder.Services.AddScoped<IKitchenRepository, KitchenRepository>();
            builder.Services.AddScoped<IPhysicalKitchenRepository, PhysicalKitchenRepository>();
            builder.Services.AddScoped<IPhysicalOrderListRepository, PhysicalOrderListRepository>();
            builder.Services.AddScoped<IPhysicalOrderRepository, PhysicalOrderRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<IVirtualKitchenRepository, VirtualKitchenRepository>();
            builder.Services.AddScoped<IVirtualOrderRepository, VirtualOrderRepository>();
            builder.Services.AddScoped<ISupplierMatrialRepository, SupplierMatrialRepository>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;

            })
            .AddEntityFrameworkStores<CloudKitchenContext>();

            //
           // builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CloudKitchenContext>().AddDefaultTokenProviders();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("KitchenPolicy", policy =>
                {
                    policy.RequireRole("Kitchen");
                });
                options.AddPolicy("ChefPolicy", policy =>
                {
                    policy.RequireRole("Chef");
                });
                options.AddPolicy("DeliveryPolicy", policy =>
                {
                    policy.RequireRole("Delivery");
                });
                options.AddPolicy("SupplierPolicy", policy =>
                {
                    policy.RequireRole("Supplier");
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            ////
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new List<IdentityRole>
    {
        new IdentityRole{Name = "Kitchen"},
        new IdentityRole{Name = "Chef"},
        new IdentityRole{Name = "Delivery"},
        new IdentityRole{Name = "Supplier"}
        ////note: is there admin or no???????
	};

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
            }



            await app.RunAsync();
            //app.Run();
        }
    }
}