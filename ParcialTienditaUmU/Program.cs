using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParcialTienditaUmU;
using ParcialTienditaUmU.CommandHandler;
using ParcialTienditaUmU.Commands;
using ParcialTienditaUmU.Configuration;
using ParcialTienditaUmU.Data;
using ParcialTienditaUmU.DTOs;
using ParcialTienditaUmU.Models;
using ParcialTienditaUmU.QueryHandler;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ParcialTienditaUmUContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParcialTienditaUmUContext") ?? throw new InvalidOperationException("Connection string 'ParcialTienditaUmUContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICommandHandler<ProductsDTO>, AddProductsCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveByIdCommands>, RemoveProductsCommandHandler>();
builder.Services.AddScoped<IQueryHandler<Products, QueryByIdCommands>, ProductsQueryHandler>();
builder.Services.AddScoped<ICommandHandler<Products>, UpdateProductsCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
