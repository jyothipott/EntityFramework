var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<APICrudOperations.EmployeeService.IEmployeeService, APICrudOperations.EmployeeService.EmployeeService>();
builder.Services.AddScoped<APICrudOperations.EmployeeRepo.IEmployeeRepo, APICrudOperations.EmployeeRepo.EmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Employee}/{id?}")
    .WithStaticAssets();

app.UseAuthorization();

app.MapControllers();

app.Run();
