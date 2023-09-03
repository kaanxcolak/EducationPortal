using AutoMapper.Extensions.ExpressionMapping;
using EducationPortalBL.ImplementationsOfManagers;
using EducationPortalBL.InterfacesOfManagers;
using EducationPortalDL;
using EducationPortalDL.ImplementationsOfRepo;
using EducationPortalDL.InterfacesOfRepo;
using EducationPortalEL.IdentityModels;
using EducationPortalEL.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevTest"));

        });

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // ayarlar eklenecek
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false; // @ / () [] {} ? : ; karakterler
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz-_0123456789";

}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoMapper ayari eklendi.
builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile(typeof(Maps));
});

//DI yasam döngüleri

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();

builder.Services.AddScoped<IEducationalContentRepo, EducationalContentRepo>();
builder.Services.AddScoped<IEducationalContentManager, EducationalContentManager>();

builder.Services.AddScoped<IEducationInfoRepo, EducationInfoRepo>();
builder.Services.AddScoped<IEducationInfoManager, EducationInfoManager>();

builder.Services.AddScoped<IEducationRequestRepo, EducationRequestRepo>();
builder.Services.AddScoped<IEducationRequestManager, EducationRequestManager>();

builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentManager, StudentManager>();

builder.Services.AddScoped<ITrainerInfoRepo, TrainerInfoRepo>();
builder.Services.AddScoped<ITrainerInfoManager, ITrainerInfoManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    var userManager = (UserManager<AppUser>?)scope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
    var roleManager = (RoleManager<AppRole>?)scope.ServiceProvider.GetService(typeof(RoleManager<AppRole>));
    // do you things here

    var CategoryManager = (ICategoryManager?)scope.ServiceProvider.GetService(typeof(ICategoryManager));

    //Devamı var!!!!!!

    //DataDefault dataDefault = new DataDefault();

    //dataDefault.CheckAndCreateRoles(roleManager);

    //dataDefault.CreateAllCargoStatus(cargoStatusManager);

    //dataDefault.CreateAllCities(cityManager);

    //dataDefault.CreateAllDistricts(districtManager);

    // dataDefault.CreateAFewEmployee(userManager,roleManager,employeeBranchManager);

}

app.Run();
