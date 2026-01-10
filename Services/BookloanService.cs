using ExamApi.Data;
using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;

namespace ExamApi.Services;
public class BookloanService(ApplicationDbContext dbContext) : IBookloanService
{
     private readonly ApplicationDbContext context = dbContext;

    public async Task<Response<string>> AddAsync(Bookloan bookloan)
    {
        try
         {
             using var conn = context.Connection();
             var query="insert into bookloans(bookid,userid,loandate,registeredat) values(@bookid,@userid,@loandate,@registeredat) ";
             var res = await conn.ExecuteAsync(query,new{bookid=bookloan.BookId,userid=bookloan.UserId,loandate=bookloan.LoanDate,registeredat=bookloan.ReturnDate});
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not add")
              : new Response<string>(HttpStatusCode.OK,"Added successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
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
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not delete")
              : new Response<string>(HttpStatusCode.OK,"Delete successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<List<Bookloan>> GetAsync()
    {
         using var conn = context.Connection();
             var query="select * from users";
             var res = await conn.QueryAsync<Bookloan>(query);
             return  res.ToList();
    }

    public  async Task<Response<Bookloan>> GetByIdAsync(int bookloanid)
    {
        try
         {
             using var conn = context.Connection();
             var query="select * from bookloans where id=@Bookloanid";
             var res = await conn.QueryFirstOrDefaultAsync(query,new{Bookloanid=bookloanid});
             return res==0? new Response<Bookloan>(HttpStatusCode.InternalServerError,"Can not Get")
              : new Response<Bookloan>(HttpStatusCode.OK,"Get successfull",res);
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<Response<string>> UpdateAsync(Bookloan bookloan)
    {
         try
         {
             using var conn = context.Connection();
             var query="update users set bookid=@Bookid,userid=@Userid,loandate=@Loandate,registeredat=Registeredat";
             var res = await conn.ExecuteAsync(query, bookloan);
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not update")
              : new Response<string>(HttpStatusCode.OK,"Update successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
}