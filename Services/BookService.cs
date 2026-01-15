using ExamApi.Data;
using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
using ExamApi.DTOs;
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
             using var conn = context.Connection();
             var query="insert into books(title,publishedyear,genre,authorid) values(@title,@publishedyear,@genre,@authorid) ";
             var res = await conn.ExecuteAsync(query,new{title=book.Title,publishedyear=book.PublishedYear,genre=book.Genre,authorid=book.AuthorId});
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
             using var conn = context.Connection();
             var query="delete from books where id=@Bookid";
             var res = await conn.ExecuteAsync(query,new{Bookid=bookid});
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
    public  async Task<List<Book>> GetAsync()
    {
          using var conn = context.Connection();
             var query="select * from books";
             var res = await conn.QueryAsync<Book>(query);
             return  res.ToList();
    }
    public  async Task<Response<Book>> GetByIdAsync(int bookid)
{
          try
         {
             using var conn = context.Connection();
             var query="select * from books where id=@Bookid";
             var res = await conn.QueryFirstOrDefaultAsync<Book>(query,new{Bookid=bookid});
            if(res==null)
             {
                logger.LogWarning("Can not found id");
                return  new Response<Book>(HttpStatusCode.NotFound,"Can not found");
            }
             else
            {
                return new Response<Book>(HttpStatusCode.OK,"Get successfull",res);
            }        
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<Book>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
}
    public async Task<Response<string>> UpdateAsync(UpdateBookDto book)
    {
         try
         {
             using var conn = context.Connection();
             var query="update books set title = @Title,publishedyear = @Publishedyear,genre = @Genre, authorid = @Authorid where id = @Id";
             var res = await conn.ExecuteAsync(query, book);
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
