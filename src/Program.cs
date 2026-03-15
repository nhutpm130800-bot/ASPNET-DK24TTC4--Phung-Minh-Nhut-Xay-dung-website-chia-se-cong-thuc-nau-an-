using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebNauAn_TVU.Models;

var builder = WebApplication.CreateBuilder(args);

// Kết nối Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Identity: Tắt hết xác thực rườm rà cho mượt
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false; // Đăng ký xong là vào luôn
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Đổi lại từ MapStaticAssets cho phổ thông
app.UseRouting();

// Thứ tự này cực kỳ quan trọng để nhận diện tài khoản
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MonAn}/{action=Index}/{id?}");

app.MapRazorPages(); // Phải có dòng này thì trang Login/Register mới hiện ra

app.Run();