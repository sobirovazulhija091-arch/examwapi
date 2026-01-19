using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
using ExamApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExamApi.Services;
public class BookloanService(ApplicationDbContext dbContext ,ILogger<Bookloan> _logger) : IBookloanService
{
    private readonly ApplicationDbContext context = dbContext;
    private readonly ILogger<Bookloan> logger = _logger;
    public async Task<Response<string>> AddAsync(BookloanDto bookloan1)
    {
        Bookloan bookloan = new Bookloan
            {
               UserId=bookloan1.UserId,
               BookId=bookloan1.BookId  
            };
        try
         {  
             context.Bookloans.Add(bookloan);
             await context.SaveChangesAsync();    
               return new Response<string>(HttpStatusCode.OK,"Added successfull");  
             
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> DeleteAsync(int bookloanid)
    {
        try
         {
               var bookloan = await context.Bookloans.FindAsync(bookloanid);
              context.Bookloans.Remove(bookloan);
               await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Delete successfull");        
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<List<Bookloan>>> GetAsync()
    {
        try
        {
             return new Response<List<Bookloan>>(HttpStatusCode.OK,"ok",await context.Bookloans.ToListAsync());
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<List<Bookloan>>(HttpStatusCode.InternalServerError, $"Something went wrong!");
        }
              
    }
    public  async Task<Response<Bookloan>> GetByIdAsync(int bookloanid)
    {
        try
         {
            var loan = await context.Bookloans.FindAsync(bookloanid);
            return new Response<Bookloan>(HttpStatusCode.OK,"oK",loan); 
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(int bookloanid,UpdateBookloanDto bookloan)
    {
         try
         {
             
             var loan = await context.Bookloans.FindAsync(bookloanid);
               loan.BookId=bookloan.BookId;
               loan.UserId=bookloan.UserId;
               loan.LoanDate=bookloan.LoanDate;
               loan.ReturnDate=loan.ReturnDate; 
               await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Update successfull");  
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<Bookloan>> ReturnAsync(int bookloanid)
    {
        try
        { 
             var  loan= await context.Bookloans.FindAsync(bookloanid);

              if (loan==null)
             {
               return new Response<Bookloan>(HttpStatusCode.NotFound,"Can not Find");
             }
                 loan.ReturnDate=DateTime.UtcNow;
                 await context.SaveChangesAsync();
               return new Response<Bookloan>(HttpStatusCode.OK,"Returned successfull");    
        }  
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
         }
    
}
