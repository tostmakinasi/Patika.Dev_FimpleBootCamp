using BookStore.API.Common;
using BookStore.API.DbOperations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "BookStoreDB");
});

builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

using(var scope = builder.Services.BuildServiceProvider())
{
    DataGenerator.Initialize(scope);
}


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
