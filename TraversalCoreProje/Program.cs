using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Primitives;
using System.Globalization;
using TraversalCoreProje.Models;


var builder = WebApplication.CreateBuilder(args);

//Dosyaya loglama
builder.Services.AddLogging(log =>
{
    log.ClearProviders();
    log.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Error);
});
//-----------------------------------------------------------------------------------------------

// Add services to the container.


//-------------------------------------------------------------------------
//log kayýtlarý
builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);//Debug: Uygulamaýn akýþý hakkýnda detaylý bilgi verir...
    x.AddDebug();
});
//Trace: en ayrýntýlý loglar, hata ayýklama..
//Debug: Uygulamaýn akýþý hakkýnda detaylý bilgi verir...
//Information: uygulamanýn genel akýþý ile ilgili bilgi
//Warning:	Olasý sorunlar hakkýnda uyarýlar
//Error:	Gerçek hatalar, genellikle hata durumlarý
//Critical:	Sistem çökmesine neden olabilecek ciddi hatalar
//--------------------------------------------------------------------------

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();



builder.Services.ContainerDependencies();//Extensions sýnýfýný static yapmak zorundayýz..





builder.Services.AddControllersWithViews().AddFluentValidation();//VAlidationun çalýþmasý için..

//---------------------------------------------------------------------
//Otantike olma iþlemi;
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
//--------------------------------------------------------------------

builder.Services.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");//404 sayfasýna gitme
app.UseHttpsRedirection();
app.UseStaticFiles();//Bu metot statik dosyalarý(css,js) sunar.
app.UseAuthentication();//Kimlik Doðrulama mekanizmasýný etkinleþtirir.
app.UseRouting();//Bu metot; gelen istekleri yönlendirmek için kullanýlýr.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
