using BaseModel.Domain.Interfaces;
using BaseModel.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
Console.WriteLine($"Environment: {environment}");

builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(51000);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddInfrastructureCors();
builder.Services.AddInfrastructureMultiTenantT();
builder.Services.AddHttpContextAccessor();

builder.Services.AddInfrastructureHosted();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
