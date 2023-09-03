using Microsoft.EntityFrameworkCore;
using Project_Spring_to_.net.Business;
using Project_Spring_to_.net.Business.Contracts;
using Project_Spring_to_.net.Data;

var builder = WebApplication.CreateBuilder(args);
string allowSpecificOrigins = "_allowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientCategoryService, ClientCategoryService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
