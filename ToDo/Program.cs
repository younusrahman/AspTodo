using Microsoft.EntityFrameworkCore;
using ToDo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ToDoDBContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("DefaultConnection")
    //IN Appsettings.json it is impotent to write DefaultConnection. Because GetConnectionString method
    //works only if name is DefaultConnection.


    //Install Microsoft.EntityFrameworkCore.Tools
    //Open tools select Nuget > console 

    // command have to use to create table : add-migration AddToDoTasks

    // if everthing goes well then use command: update-database


    )); // have to add this for sql server

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
