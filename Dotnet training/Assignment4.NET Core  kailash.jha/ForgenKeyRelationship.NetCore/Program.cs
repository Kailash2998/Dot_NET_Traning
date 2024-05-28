using ForgenKeyRelationship.NetCore.Data;
using ForgenKeyRelationship.NetCore.Repository.Interface;
using ForgenKeyRelationship.NetCore.Repository.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<BookManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForgenKey")));

// Add repository service
builder.Services.AddScoped(typeof(IRepository<>), typeof(Service<>));



/*// Add to the database connections 
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<BookManagementContext>(item => item.UseSqlServer(config.GetConnectionString("ForgenKey")));
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Service<>));
*/
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
