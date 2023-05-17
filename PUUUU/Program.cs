using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PUUUU.Data;
using PUUUU.Models.Models;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("test"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

    List<Bike> bikes = new List<Bike>()
        {
            new Bike() { Id = 1, Brand = "Trek", Model = "Fuel EX 8", Type = "Mountain Bike", Size = "Medium", Price = 3500.00, Quantity = 3 },
            new Bike() { Id = 2, Brand = "Specialized", Model = "Diverge", Type = "Gravel Bike", Size = "Large", Price = 2500.00, Quantity = 5 },
            new Bike() { Id = 3, Brand = "Giant", Model = "TCR Advanced Pro 2", Type = "Road Bike", Size = "Small", Price = 3600.00, Quantity = 2 },
            new Bike() { Id = 4, Brand = "Cannondale", Model = "Topstone Carbon", Type = "Gravel Bike", Size = "Medium", Price = 3200.00, Quantity = 4 },
            new Bike() { Id = 5, Brand = "Santa Cruz", Model = "Hightower C S", Type = "Mountain Bike", Size = "Large", Price = 5400.00, Quantity = 1 },
            new Bike() { Id = 6, Brand = "Kona", Model = "Sutra LTD", Type = "Touring Bike", Size = "Small", Price = 2700.00, Quantity = 2 },
            new Bike() { Id = 7, Brand = "Scott", Model = "Addict RC 20", Type = "Road Bike", Size = "Medium", Price = 3800.00, Quantity = 1 },
            new Bike() { Id = 8, Brand = "Surly", Model = "Bridge Club", Type = "Gravel Bike", Size = "Large", Price = 1800.00, Quantity = 6 },
            new Bike() { Id = 9, Brand = "Cervelo", Model = "Aspero-5 GRX 810", Type = "Gravel Bike", Size = "Medium", Price = 4900.00, Quantity = 3 },
            new Bike() { Id = 10, Brand = "Bianchi", Model = "Infinito CV Disc", Type = "Road Bike", Size = "Large", Price = 4600.00, Quantity = 2 },
        };

    List<BikePart> bikeParts = new List<BikePart>
        {
            new BikePart { Id = 1, Name = "Shimano Ultegra Crankset", Description = "High-performance crankset for road bikes", Type = "Crankset", Price = 349.99, Quantity = 10 },
            new BikePart { Id = 2, Name = "SRAM GX Eagle Cassette", Description = "12-speed cassette for mountain bikes", Type = "Cassette", Price = 149.99, Quantity = 5 },
            new BikePart { Id = 3, Name = "Continental Grand Prix 5000 Tires", Description = "Top-of-the-line road bike tires with excellent grip and durability", Type = "Tires", Price = 79.99, Quantity = 20 },
            new BikePart { Id = 4, Name = "RockShox Reverb Dropper Post", Description = "Adjustable dropper post for mountain bikes", Type = "Dropper Post", Price = 399.99, Quantity = 8 },
            new BikePart { Id = 5, Name = "Shimano XT Disc Brake Set", Description = "Hydraulic disc brake set for mountain bikes", Type = "Brakes", Price = 249.99, Quantity = 12 },
            new BikePart { Id = 6, Name = "Schwalbe Marathon Plus Tires", Description = "Highly puncture-resistant touring bike tires", Type = "Tires", Price = 59.99, Quantity = 15 },
            new BikePart { Id = 7, Name = "Shimano Deore XT Rear Derailleur", Description = "10-speed rear derailleur for mountain bikes", Type = "Derailleur", Price = 89.99, Quantity = 6 },
            new BikePart { Id = 8, Name = "Brooks B17 Saddle", Description = "Classic leather saddle for touring bikes", Type = "Saddle", Price = 129.99, Quantity = 3 },
            new BikePart { Id = 9, Name = "Park Tool PCS-10.2 Bike Repair Stand", Description = "Portable bike repair stand for home mechanics", Type = "Repair Stand", Price = 219.99, Quantity = 4 },
            new BikePart { Id = 10, Name = "Thomson Elite Seatpost", Description = "High-strength aluminum seatpost for road and mountain bikes", Type = "Seatpost", Price = 79.99,Quantity = 7 },
        };
    bikes.ForEach(b => db.Bikes.Add(b));
    bikeParts.ForEach(b => db.BikeParts.Add(b));

    db.SaveChanges();

    var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    if (roleManager != null)
    {
        if (!roleManager.RoleExistsAsync("Administrator").Result)
            roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administrator"
            });
        if (!roleManager.RoleExistsAsync("User").Result)
            roleManager.CreateAsync(new IdentityRole()
            {
                Name = "User"
            });
    }

    var createAdmin = userManager.CreateAsync(
        new IdentityUser()
        {
            UserName = "test@test.com",
            Email = "test@test.com",
        }, "Test12345!");
    var admin = userManager.FindByNameAsync("test@test.com").Result;

    var verificationCode = userManager.GenerateEmailConfirmationTokenAsync(admin).Result;
    // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

    var result = userManager.ConfirmEmailAsync(admin, verificationCode).Result;

    userManager.AddToRoleAsync(admin, "Administrator");
}
app.Run();




