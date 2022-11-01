using Cineminha.Apresentacao.Mvc.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => 
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddRazorPages();

builder.Services.AddPaging(options => {
    options.ViewName = "Bootstrap4";
    options.PageParameterName = "page";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Authentication/LoginExecute");
        options.LogoutPath = new PathString("/Authentication/LogoutExecute");
        options.AccessDeniedPath = new PathString("/Authentication/AccessDenied");
    });

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=LoginExecute}");

app.MapRazorPages();

app.Run();
