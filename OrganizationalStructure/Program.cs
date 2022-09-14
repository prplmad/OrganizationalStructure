using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repository;
using BL.Abstract.AbstractRepository;
using BL.Services;
using BL.Abstract;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings:Database").Value));
builder.Services.AddTransient<IImportService, ImportService>();
builder.Services.AddTransient<IImportRepository, ImportRepository>();
builder.Services.AddTransient<IOrgStructureRepository, OrgStructureRepository>();
builder.Services.AddTransient<IOrgStructureService, OrgStructureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Import/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Import}/{action=Index}/{id?}");

app.Run();
