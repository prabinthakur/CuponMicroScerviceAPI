using CuponMicroService.WebApp.Service;
using CuponMicroService.WebApp.Service.Iservice;
using CuponMicroService.WebApp.Utilities;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICuponService,CuponService>();

SD.CuponApiBase = builder.Configuration["ServiceUrls:CuponAPI"];


builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICuponService, CuponService>();
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
