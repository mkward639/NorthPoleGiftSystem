using NorthPoleGiftSystem.NorthPole.Data;
using Microsoft.EntityFrameworkCore;
using NorthPoleGiftSystem.NorthPoleServices;
using NorthPoleGiftSystem.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NorthPoleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IElfService, ElfService>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IWorkshopService, WorkshopService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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
