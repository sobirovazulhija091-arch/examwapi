using ExamApi.Data;
using ExamApi.Entites;
using ExamApi.Interface;
using ExamApi.Services;
using ExamApi.Responses;
using Microsoft.AspNetCore.Mvc;
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserServiceController(IUserService userService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(User user)
    {
        return await userService.AddAsync(user);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int userid)
    {
        return await userService.DeleteAsync(userid);
    }
    [HttpGet]
    public async Task<List<User>> GetAsync()
    {
        return await userService.GetAsync();
    }
    [HttpGet("userid")]
     public async Task<Response<User>> GetByIdAsync(int userid)
    {
      return await userService.GetByIdAsync(userid);   
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(User user)
    {
        return await userService.UpdateAsync(user);
    }
}