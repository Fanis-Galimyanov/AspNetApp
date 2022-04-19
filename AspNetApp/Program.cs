using AspNetApp.interfaces;
using AspNetApp.mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IAllCars, MockCars>();
builder.Services.AddTransient<ICarsCategory, MockCategory>();
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
