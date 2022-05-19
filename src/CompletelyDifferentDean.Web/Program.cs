using CompletelyDifferentDean.Application;
using CompletelyDifferentDean.Database;
using CompletelyDifferentDean.Dto;
using CompletelyDifferentDean.Dto.Disciplines;
using CompletelyDifferentDean.Infrastructure;
using CompletelyDifferentDean.Infrastructure.Services;
using CompletelyDifferentDean.Web;
using CompletelyDifferentDean.Web.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseContext(builder.Configuration);

builder.Services.AddDefaultIdentity<IdentityUser>(options => {
        options.SignIn.RequireConfirmedAccount = true;
        options.Stores.MaxLengthForKeys = 128;
    })
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDto();
builder.Services.AddRepositories();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.ConfigureLocalization();

builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDtoLocalization()
    .AddFluentValidation(fv => {
            fv.RegisterValidatorsFromAssemblyContaining<DisciplineValidator>();
            fv.DisableDataAnnotationsValidation = true;
            fv.ConfigureClientsideValidation();
        });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseRequestLocalization();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
