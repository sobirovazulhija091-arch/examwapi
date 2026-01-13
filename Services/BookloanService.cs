using ExamApi.Data;
using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
using ExamApi.DTOs;

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
             using var conn = context.Connection();
             var query="insert into bookloans(bookid,userid,loandate,returndate) values(@bookid,@userid,@loandate,@returndate) ";
             var res = await conn.ExecuteAsync(query,new{bookid=bookloan.BookId,userid=bookloan.UserId,loandate=bookloan.LoanDate,returndate=bookloan.ReturnDate});
            if (res==0)
             {
                logger.LogWarning("Can not add  by id");
               return new Response<string>(HttpStatusCode.InternalServerError,"Can not add");
             }
             else
             {
              
               return new Response<string>(HttpStatusCode.OK,"Added successfull");  
             }
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
             using var conn = context.Connection();
             var query="delete from bookloans where id=@Bookloanid";
             var res = await conn.ExecuteAsync(query,new{Bookloanid=bookloanid});
            if (res==0)
             {
                logger.LogWarning("Can not delete  by id");
               return new Response<string>(HttpStatusCode.InternalServerError,"Can not delete");
             }
             else
             {
              
               return new Response<string>(HttpStatusCode.OK,"Delete successfull");  
             }
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<List<Bookloan>> GetAsync()
    {
              using var conn = context.Connection();
              var query="select * from bookloans";
              var res = await conn.QueryAsync<Bookloan>(query);
              return  res.ToList();
    }
    public  async Task<Response<Bookloan>> GetByIdAsync(int bookloanid)
    {
        try
         {
             using var conn = context.Connection();
             var query="select * from bookloans where id=@Bookloanid";
             var res = await conn.QueryFirstOrDefaultAsync<Bookloan>(query,new{Bookloanid=bookloanid});
             if (res==null)
             {
                logger.LogWarning("Can not find  id");
               return new Response<Bookloan>(HttpStatusCode.NotFound,"Can not find");
             }
             else
             {
              
               return new Response<Bookloan>(HttpStatusCode.OK,"Get successfull");  
             }
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(UpdateBookloanDto bookloan)
    {
         try
         {
             using var conn = context.Connection();
             var query="update bookloans set bookid=@Bookid,userid=@Userid,loandate=@Loandate,returndate=@Returndate where id=@Id";
             var res = await conn.ExecuteAsync(query, bookloan);
            if (res==0)
             {
                logger.LogWarning("Can not update  by id");
               return new Response<string>(HttpStatusCode.InternalServerError,"Can not update");
             }
             else
             {
              
               return new Response<string>(HttpStatusCode.OK,"Update successfull");  
             }
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
          using var conn = context.Connection();
             var query="update bookloans set returndate = @ReturnDate where id=@Id";
            var res = await conn.ExecuteAsync(query, new { ReturnDate = DateTime.UtcNow, Id = bookloanid });
              if (res==0)
             {
                logger.LogWarning("Can not return  ");
               return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Can not return date");
             }
             else
             {
              
               return new Response<Bookloan>(HttpStatusCode.OK,"Returned successfull");  
             }   
        }  
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
         }
    
}
