using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegexMaster.DB;
using RegexMaster.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationContext"));
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddApiEndpoints();

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapIdentityApi<User>();

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
