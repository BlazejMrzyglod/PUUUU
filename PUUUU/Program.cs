using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PUUUU.Data;
using PUUUU.Models.Models;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("test"));//UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IEmailSender, SendMail>();
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

    List<Bike> bikes = new List<Bike>()
        {
            new Bike() {Brand = "Trek", Model = "Fuel EX 8", Type = "G�rski", Size = "�redni", Price = 3500.00, Quantity = 3, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Specialized", Model = "Diverge", Type = "G�rski", Size = "Du�y", Price = 2500.00, Quantity = 5, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk="},
            new Bike() { Brand = "Giant", Model = "TCR Advanced Pro 2", Type = "Drogowy", Size = "Ma�y", Price = 3600.00, Quantity = 2 , Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk="},
            new Bike() { Brand = "Cannondale", Model = "Topstone Carbon", Type = "G�rski", Size = "�redni", Price = 3200.00, Quantity = 4, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Santa Cruz", Model = "Hightower C S", Type = "G�rski", Size = "Du�y", Price = 5400.00, Quantity = 1, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Kona", Model = "Sutra LTD", Type = "Touringowy", Size = "Ma�y", Price = 2700.00, Quantity = 2, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Scott", Model = "Addict RC 20", Type = "Drogowy", Size = "�redni", Price = 3800.00, Quantity = 1, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Surly", Model = "Bridge Club", Type = "G�rski", Size = "Du�y", Price = 1800.00, Quantity = 6, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Cervelo", Model = "Aspero-5 GRX 810", Type = "G�rski", Size = "�redni", Price = 4900.00, Quantity = 3, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
            new Bike() { Brand = "Bianchi", Model = "Infinito CV Disc", Type = "Drogowy", Size = "Du�y", Price = 4600.00, Quantity = 2, Image = "https://media.istockphoto.com/id/185313478/photo/cmyk-color-guide-and-lorem-ipsum-text.jpg?s=612x612&w=0&k=20&c=llnNEei8KmQBbZkXJYEOl2wdHMs3d9vly7gp9oN4jJk=" },
        };

    List<BikePart> bikeParts = new List<BikePart>
        {
            new BikePart {  Name = "Shimano Ultegra Crankset", Description = "High-performance crankset for road bikes", Type = "Frame", Price = 349.99, Quantity = 10 },
            new BikePart { Name = "SRAM GX Eagle Cassette", Description = "12-speed cassette for mountain bikes", Type = "Fork", Price = 149.99, Quantity = 5 },
            new BikePart { Name = "Continental Grand Prix 5000 Tires", Description = "Top-of-the-line road bike tires with excellent grip and durability", Type = "Wheels", Price = 79.99, Quantity = 20 },
            new BikePart { Name = "RockShox Reverb Dropper Post", Description = "Adjustable dropper post for mountain bikes", Type = "Saddle", Price = 399.99, Quantity = 8 },
            new BikePart { Name = "Shimano XT Disc Brake Set", Description = "Hydraulic disc brake set for mountain bikes", Type = "Handle", Price = 249.99, Quantity = 12 },
            new BikePart { Name = "Schwalbe Marathon Plus Tires", Description = "Highly puncture-resistant touring bike tires", Type = "Pedals", Price = 59.99, Quantity = 15 },
            new BikePart { Name = "Shimano Deore XT Rear Derailleur", Description = "10-speed rear derailleur for mountain bikes", Type = "Frame", Price = 89.99, Quantity = 6 },
            new BikePart { Name = "Brooks B17 Saddle", Description = "Classic leather saddle for touring bikes", Type = "Saddle", Price = 129.99, Quantity = 3 },
            new BikePart { Name = "Park Tool PCS-10.2 Bike Repair Stand", Description = "Portable bike repair stand for home mechanics", Type = "Wheels", Price = 219.99, Quantity = 4 },
            new BikePart { Name = "Thomson Elite Seatpost", Description = "High-strength aluminum seatpost for road and mountain bikes", Type = "Handle", Price = 79.99,Quantity = 7 },
        };
    bikes.ForEach(b => db.Bikes.Add(b));
    bikeParts.ForEach(b => db.BikeParts.Add(b));

    db.SaveChanges();

    var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    if (roleManager != null)
    {
        if (!roleManager.RoleExistsAsync("Administrator").Result)
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administrator"
            });
        if (!roleManager.RoleExistsAsync("User").Result)
            await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
    }

    var createAdmin = await userManager.CreateAsync(
        new IdentityUser()
        {
            UserName = "test@test.com",
            Email = "test@test.com",
        }, "Test12345!");
    var admin =  userManager.FindByNameAsync("test@test.com").Result;

    var verificationCode = userManager.GenerateEmailConfirmationTokenAsync(admin).Result;
    // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

    var result = userManager.ConfirmEmailAsync(admin, verificationCode).Result;

    userManager.AddToRoleAsync(admin, "Administrator");



}
app.Run();




