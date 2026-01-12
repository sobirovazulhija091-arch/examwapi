using ExamApi.Data;
using ExamApi.Entites;
using ExamApi.Interface;
using ExamApi.Services;
using ExamApi.Responses;
using ExamApi.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace ExamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorServiceController(IAuthorService authorService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> AddAsync(AuthorDto author)
    {
        return await authorService.AddAsync(author);
    }

    [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int authorid)
    {
        return await authorService.DeleteAsync(authorid);
    }
    [HttpGet]
     public async Task<List<Author>> GetAsync()
    {
        return await authorService.GetAsync();
    }
    [HttpGet("authorid")]

    public async Task<Response<Author>>  GetByIdAsync(int authorid)
    {
         return await authorService.GetByIdAsync(authorid);
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(UpdateAuthorDto author)
    {
        return await authorService.UpdateAsync(author);
    }
}
