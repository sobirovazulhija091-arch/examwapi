using ExamApi.Data;
using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;

namespace ExamApi.Services;
public class UserService(ApplicationDbContext dbContext) : IUserService
{
     private readonly ApplicationDbContext context = dbContext;

    public async Task<Response<string>> AddAsync(User user)
    {
         try
         {
             using var conn = context.Connection();
             var query="insert into users(fullname,email,registeredat) values(@fullname,@email,@registeredat) ";
             var res = await conn.ExecuteAsync(query,new{fullname=user.FullName,email=user.Email,registeredat=user.RegisteredAt});
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not add")
              : new Response<string>(HttpStatusCode.OK,"Added successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<Response<string>> DeleteAsync(int userid)
    {
        try
         {
             using var conn = context.Connection();
             var query="delete from users where id=@Userid";
             var res = await conn.ExecuteAsync(query,new{Userid=userid});
             return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not delete")
              : new Response<string>(HttpStatusCode.OK,"Delete successfull");
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<List<User>> GetAsync()
    {
        using var conn = context.Connection();
             var query="select * from users";
             var res = await conn.QueryAsync<User>(query);
             return  res.ToList();
    }

    public async Task<Response<User>> GetByIdAsync(int userid)
    {
        try
         {
             using var conn = context.Connection();
             var query="select * from users where id=@Userid";
             var res = await conn.QueryFirstOrDefaultAsync(query,new{Userid=userid});
             return res==0? new Response<User>(HttpStatusCode.InternalServerError,"Can not Get")
              : new Response<User>(HttpStatusCode.OK,"Get successfull",res);
         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex);
             return new Response<User>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }

    public async Task<Response<string>> UpdateAsync(User user)
    {
        try
         {
             using var conn = context.Connection();
             var query="update users set fullname=Fullname,email=Email,registeredat=Registeredat";
             var res = await conn.ExecuteAsync(query, user);
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