using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace FinalASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //
            builder.Services.AddDbContext<CloudKitchenContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("G"))
            );
            //

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}