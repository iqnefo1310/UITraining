using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrasi layanan dilakukan **sebelum** pemanggilan builder.Build()
//    Ini penting agar semua layanan tersedia dalam Dependency Injection (DI) container.

builder.Services.AddControllersWithViews(); // Menambahkan layanan controller dengan views.

// Konfigurasi versi server MySQL
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

// 2. Menambahkan konfigurasi DbContext ke DI container.
//    Pastikan registrasi DbContext dilakukan sebelum builder.Build().
builder.Services.AddDbContext<ApplicationContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration.GetConnectionString("MySQLconnection"), serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// 3. Menambahkan layanan ProductServices ke DI container.
builder.Services.AddScoped<IProduct,ProductServices>();
builder.Services.AddScoped<ISupplier,SupplierServices>();
builder.Services.AddScoped<IUserAccess,UserAccessServices>();

// 4. Setelah semua layanan didaftarkan, barulah memanggil Build() untuk membuat aplikasi.
var app = builder.Build();

// Konfigurasi middleware pipeline untuk menangani request.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Pengaturan rute default.
app.MapControllerRoute(
    name: "default",
pattern: "{controller=UserAccess}/{action=RegisterUser}/{id?}");
app.Run();
