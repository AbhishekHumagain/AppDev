using System.Text.Json;
using AppDev.Application.DTOs;
using AppDev.Infrastructure.DI;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
// builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddAuthentication();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("https://localhost:7158/",
                "http://localhost:5011/");
        });
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToAccessDenied = context =>
    {
        var errorMessage = new ErrorMessageResponse { Message = "Forbidden" };
        context.Response.StatusCode = 403;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
    };
    options.Events.OnRedirectToLogin = context =>
    {
        var errorMessage = new ErrorMessageResponse { Message = "Unauthorized" };
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseRouting(); //for identity
app.UseAuthentication(); //for identity
app.UseAuthorization();
// app.UseCors(myAllowSpecificOrigins);


app.MapControllers();

app.Run();