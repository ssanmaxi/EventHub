using EventPlanning.Application.Dependency;
using EventPlanning.Application.Dependency.Auth_DI;
using EventPlanning.Infrastructure.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", p => p.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod().AllowAnyHeader()));


var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();