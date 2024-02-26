using Microsoft.EntityFrameworkCore;
using RPAdev.BlazorServer.App.Configurations;
using RPAdev.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// ########## Add Services ##########
//usando o SQL Server como DB principal
builder.Services.AddDbContext<AppDbContext>(opt => { 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//configuracoes da injeção de dependencia
builder.Services.ResolveDependencies();

var app = builder.Build();




// ########## Configure Services ##########
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
