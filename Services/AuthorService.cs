using System.Net;
using ExamApi.Entites;
using ExamApi.DTOs;
using Dapper;
using Microsoft.EntityFrameworkCore;
// using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
namespace ExamApi.Services;

public class AuthorService(ApplicationDbContext dbContext,ILogger<Author> _logger) : IAuthorService
{
    private readonly ILogger<Author> logger = _logger;
    private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> AddAsync(AuthorDto author1)
    {
            Author author = new Author
            {
               FullName=author1.FullName,
               BirthDate=author1.BirthDate,
               Country=author1.Country
            };
             context.Authors.Add(author);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK, "Added Successfully!");
         }
    public async Task<Response<string>> DeleteAsync(int authorid)
    {
        try
         {
              var author = await context.Authors.FindAsync(authorid);
            context.Authors.RemoveRange(author);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK, "deleted successfully!");
             }
             catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<Response<List<Author>>> GetAsync()
    {
      try
        {
            var res = context.Authors.Include(a=>a.Books).ToList();
            return new Response<List<Author>>(HttpStatusCode.OK, "Ok", res);
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex);
            return new Response<List<Author>>(HttpStatusCode.InternalServerError, $"Something went wrong!");
        }
 
   }
    public async Task<Response<Author>> GetByIdAsync(int authorid)
    {
         try
         {
          var res = context.Authors.Include(a => a.Books).First(a=>a.Id==authorid);
            return new Response<Author>(HttpStatusCode.OK, "Found successfully!", res);      
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<Author>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(int authorid,UpdateAuthorDto author)
    {
         try
         {
           var autor = await context.Authors.FindAsync(authorid);
            autor.FullName = author.FullName;
            autor.BirthDate = author.BirthDate;
            autor.Country = author.Country;
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK, "updated successfully!"); 
         }
             catch (System.Exception ex)
             {
               logger.LogError(ex.Message);
               return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
             }
         }       

}


