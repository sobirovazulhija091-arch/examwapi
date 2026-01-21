using ExamApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using ExamApi.Interface;
using ExamApi.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IProfileService,ProfileService>();
builder.Services.AddScoped<IBookloanService,BookloanService>();
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
  app.UseRouting();
app.UseMiddleware<RequestTimeMiddleware>();
app.MapControllers();

  app.Run();
