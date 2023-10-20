using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RenamerWeb.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using RenamerWeb.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Extensions.Options;

namespace RenamerWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<RenamerWebContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RenamerWebContext") ?? throw new InvalidOperationException("Connection string 'RenamerWebContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}