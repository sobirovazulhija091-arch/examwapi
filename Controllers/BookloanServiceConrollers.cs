using ExamApi.Data;
using ExamApi.Entites;
using ExamApi.Interface;
using ExamApi.Services;
using ExamApi.Responses;
using Microsoft.AspNetCore.Mvc;
using ExamApi.DTOs;
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class BookloanServiceControllers(IBookloanService bookloanService):ControllerBase
{
    [HttpPost]
      public async Task<Response<string>> AddAsync(BookloanDto bookloan)
    {
        return await bookloanService.AddAsync(bookloan);
    }
    [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int bookloanid)
    {
        return await  bookloanService.DeleteAsync(bookloanid);
    }
    [HttpGet]
     public async Task<List<Bookloan>> GetAsync()
    {
        return await bookloanService.GetAsync();
    }
    [HttpGet("bookloanid")]
     public  async Task<Response<Bookloan>> GetByIdAsync(int bookloanid)
    {
        return await bookloanService.GetByIdAsync(bookloanid);
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(Bookloan bookloan)
    {
        return await bookloanService.UpdateAsync(bookloan);
    }
}