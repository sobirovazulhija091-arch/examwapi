using ExamApi.Middlewares;
using ExamApi.Interface;
using ExamApi.Data;
using ExamApi.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IBookloanService,BookloanService>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(config=> 
 {config.AddConsole();});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
  app.MapOpenApi();
  app.UseMiddleware<RequestTimeMiddleware>();
  app.MapControllers();
  app.Run();
