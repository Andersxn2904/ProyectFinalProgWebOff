using FluentMigrator.Runner;
using DanderiTV.Layer.Application;
using System.Reflection;
using DanderiTV.Layer.DataAccess.Contexts;
using DanderiTV.Layer.DataAccess;
using DanderiTV.Layer.DataAccess.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
//        .AddFluentMigratorCore()
//        .ConfigureRunner(c => c.AddSqlServer()  
//            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("ConnetionMaster"))
//            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());



builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IServiceProvider, ServiceProvider>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<DatabaseSetting>();
builder.Services.AddScoped<IMigrationRunner, MigrationRunner>();
builder.Services.AddApplicationLayer();
builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("ConnetionMaster"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.All());







var app = builder.Build();








//app.MigrateDatabase();



//public static IServiceProvider CreateServices()
//{
//    return app.Services
//        .AddFluentMigratorCore()
//        .ConfigureRunner(rb => rb
//            .AddDapper()
//            .WithGlobalConnectionString("tu_cadena_de_conexion")
//            .ScanIn(typeof(Program).Assembly).For.Migrations())
//        .AddLogging(lb => lb.AddFluentMigratorConsole())
//        .BuildServiceProvider(false);
//}


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

//Esto sirve para ejecutar el migration

//using (var scope = app.Services.CreateScope())
//{

//    var services = scope.ServiceProvider;


//    var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
//migrationService.MigrateUp();
//    migrationService.ListMigrations();


//}

app.Run();


