
using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
using ExamApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExamApi.Services;
public class UserService(ApplicationDbContext dbContext,ILogger<User> _logger) : IUserService
{
    private readonly ILogger<User> logger = _logger;
    private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> AddAsync(UserDto user1)
    {
         try
         {
            User user = new User
            {
              FullName=user1.FullName,
              Email=user1.Email  
            };
              context.Users.Add(user);
              await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Added successfull");  
             
         }
         catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<Response<string>> DeleteAsync(int userid)
    {
        try
         {
             var res = await context.Users.FindAsync(userid);
             context.Users.Remove(res);
             await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Delete successfull");  
             }
             catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<Response<List<User>>> GetAsync()
    {
       var res = await context.Users.Include(a=>a.Profile).ToListAsync();
       return new Response<List<User>>(HttpStatusCode.OK,"ok",res);
    }
    public async Task<Response<User>> GetByIdAsync(int userid)
    {
        try
         {
               var res = await context.Users.FindAsync(userid);
                return new Response<User>(HttpStatusCode.OK,"Get successfull",res);      
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<User>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(int userid,UpdateUserDto user)
    {
        try
         {
              var  userss = await context.Users.FindAsync(userid);  
             userss.FullName=user.FullName;
             userss.Email=user.Email;
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