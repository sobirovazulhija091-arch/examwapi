
using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
using ExamApi.DTOs;
using Microsoft.EntityFrameworkCore;
namespace ExamApi.Services;
public class BookService(ApplicationDbContext dbContext,ILogger<Book> _logger) : IBookService
{
    private readonly ILogger<Book> logger = _logger;
    private readonly ApplicationDbContext context = dbContext;
    public async  Task<Response<string>> AddAsync(BookDto book1)
    {
         try
         {
            Book book = new Book
            {
               Title=book1.Title,
               PublishedYear=book1.PublishedYear,
               Genre=book1.Genre,
               AuthorId=book1.AuthorId  
            };
             context.Books.Add(book);
             await context.SaveChangesAsync();
             return new Response<string>(HttpStatusCode.OK,"Added successfully");
         }
         catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<Response<string>> DeleteAsync(int bookid)
    {
        try
         {
            var book = await context.Books.FindAsync(bookid);
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");   
         }
             catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public  async Task<Response<List<Book>>> GetAsync()
    {
          try
          {
            var res= context.Books.Include(a=>a.Bookloans).ToList();
            return new Response<List<Book>>(HttpStatusCode.OK,"Ok", res);
          }
          catch (System.Exception ex)
          {
             System.Console.WriteLine(ex);
            return new Response<List<Book>>(HttpStatusCode.InternalServerError, $"Something went wrong!");
          }
    }
    public  async Task<Response<Book>> GetByIdAsync(int bookid)
{
          try
         {
             var res =  context.Books.Include(a=>a.Bookloans).First(a=>a.Id==bookid);
             return new Response<Book>(HttpStatusCode.OK,"OK",res);
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<Book>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
}
    public async Task<Response<string>> UpdateAsync(int bookid,UpdateBookDto book)
    {
         try
         {
           
             var bookk = await context.Books.FindAsync(bookid);
             bookk.Title = book.Title;
             bookk.PublishedYear = book.PublishedYear;
             bookk.Genre = book.Genre; 
             bookk.AuthorId = book.AuthorId; 
             await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Update successfull");  
             
          }
             catch (System.Exception ex)
             {
               logger.LogError(ex.Message);
               return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
             }
    }
}
