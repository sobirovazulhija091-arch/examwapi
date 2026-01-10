using ExamApi.Data;
using System.Net;
using ExamApi.Entites;
using Dapper;
// using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
namespace ExamApi.Services;

public class AuthorService(ApplicationDbContext dbContext) : IAuthorService
{
     private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> AddAsync(Author author)
    {
         try
         {
             using var conn = context.Connection();
             var query="insert into authors(fullname,birthdate,country) values(@fullname,@birthdate,@country)";
             var res = await conn.ExecuteAsync(query,new{fullname=author.FullName,birthdate=author.BirthDate,country=author.Country});
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not add")
              : new Response<string>(HttpStatusCode.OK,"Added successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<Response<string>> DeleteAsync(int authorid)
    {
        try
         {
             using var conn = context.Connection();
             var query="delete from authors where id=@Authorid";
             var res = await conn.ExecuteAsync(query,new{Authorid=authorid});
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not delete")
              : new Response<string>(HttpStatusCode.OK,"Delete successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<List<Author>> GetAsync()
    {
             using var conn = context.Connection();
             var query="select * from authors where id=@authorid";
             var res = await conn.QueryAsync<Author>(query);
             return  res.ToList();
    }

    public async Task<Response<Author>> GetByIdAsync(int authorid)
    {
         try
         {
             using var conn = context.Connection();
             var query="select * from authors where id=@Authorid";
             var res = await conn.QueryFirstOrDefaultAsync(query,new{Authorid=authorid});
             return res==0? new Response<Author>(HttpStatusCode.InternalServerError,"Can not Get")
              : new Response<Author>(HttpStatusCode.OK,"Get successfull",res);
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<Author>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<Response<string>> UpdateAsync(Author author)
    {
         try
         {
             using var conn = context.Connection();
             var query="update authors set fullname=@Fullname,birthdate=@Birthdate,country=@Country";
             var res = await conn.ExecuteAsync(query, author);
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

