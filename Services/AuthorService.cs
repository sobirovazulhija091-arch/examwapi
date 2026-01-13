using ExamApi.Data;
using System.Net;
using ExamApi.Entites;
using ExamApi.DTOs;
using Dapper;
// using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
namespace ExamApi.Services;

public class AuthorService(ApplicationDbContext dbContext,ILogger<Author> _logger) : IAuthorService
{
     private readonly ILogger<Author> logger =_logger;
     private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> AddAsync(AuthorDto author1)
    {
            Author author = new Author
            {
               FullName=author1.FullName,
               BirthDate=author1.BirthDate,
               Country=author1.Country
            };
             using var conn = context.Connection();
             var query="insert into  authors(fullname,birthdate,country) values(@fullname,@birthdate,@country)";
             var res = await conn.ExecuteAsync(query,new{fullname=author.FullName,birthdate=author.BirthDate,country=author.Country});
             if (res==0)
             {
                logger.LogWarning("Can not added");
               return new Response<string>(HttpStatusCode.InternalServerError,"Can not added");
             }
             else
             {
               return new Response<string>(HttpStatusCode.OK,"Added successfull");  
             }
         }
    public async Task<Response<string>> DeleteAsync(int authorid)
    {
        try
         {
            logger.LogInformation("Project runed");
             using var conn = context.Connection();
             var query="delete from authors where id=@Authorid";
             var res = await conn.ExecuteAsync(query,new{Authorid=authorid});
             if (res==0)
             {
                logger.LogWarning("Can not delete author by id");
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
    public async Task<List<Author>> GetAsync()
    {
           
             using var conn = context.Connection();
             var query="select * from authors ";
             var res = await conn.QueryAsync<Author>(query);
             return  res.ToList();
    }
    public async Task<Response<Author>> GetByIdAsync(int authorid)
    {
         try
         {
            logger.LogInformation("Project started");
             using var conn = context.Connection();
             var query="select * from authors where id=@Authorid";
             var res = await conn.QueryFirstOrDefaultAsync<Author>(query,new{Authorid=authorid});
             if(res==null)
             {
                logger.LogWarning("Can mot found id");
                return  new Response<Author>(HttpStatusCode.NotFound,"Can not found");
            }
             else
            {
                return new Response<Author>(HttpStatusCode.OK,"Get successfull",res);
            }        
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<Author>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(UpdateAuthorDto author)
    {
         try
         {
             using var conn = context.Connection();
             var query="update authors set fullname=@Fullname,birthdate=@Birthdate,country=@Country where id=@Id";
             var res = await conn.ExecuteAsync(query, author);
              if (res==0)
             {
                logger.LogWarning("Can not update author by id");
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

}


