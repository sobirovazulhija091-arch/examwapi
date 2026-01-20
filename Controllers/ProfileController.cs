
using ExamApi.Entites;
using ExamApi.Interface;
using ExamApi.Services;
using ExamApi.Responses;
using Microsoft.AspNetCore.Mvc;
using ExamApi.DTOs;
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProfileController(IProfileService profileService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> Add(int userId,string Name)
    {
         return await profileService.Add(userId,Name);
    }
    [HttpGet]
    public async Task<Response<List<Profile>>> GetAll()
    {
        return await profileService.GetAll();
    }
    
}