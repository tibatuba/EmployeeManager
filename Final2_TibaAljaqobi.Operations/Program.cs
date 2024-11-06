using Final2_TibaAljaqobi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with SQLite
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConn")));

// Register the IEmployeeServices and IDepartmentServices dependencies
builder.Services.AddScoped<IEmployeeServices, EmployeeRespository>();
builder.Services.AddScoped<IDepartmentServices, DepartmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
