using ExamApi.Interface;
using ExamApi.Data;
using ExamApi.Responses;
using ExamApi.Services;
using ExamApi.DTOs;
using ExamApi.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IBookloanService,BookloanService>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

   app.MapOpenApi();
   app.MapControllers();
  app.Run();
