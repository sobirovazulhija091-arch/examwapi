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
public class BookServiceController(IBookService  bookService):ControllerBase
{
    [HttpPost]
     public async  Task<Response<string>> AddAsync(BookDto book)
    {
        return await bookService.AddAsync(book);
    }
    [HttpDelete]
      public async Task<Response<string>> DeleteAsync(int bookid)
    {
        return await bookService.DeleteAsync(bookid);
    }
    [HttpGet]
    public  async Task<List<Book>> GetAsync()
    {
        return await bookService.GetAsync();
    }
    [HttpGet("bookid")]
    public  async Task<Response<Book>> GetByIdAsync(int bookid)
    {
        return await bookService.GetByIdAsync(bookid);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(UpdateBookDto book)
    {
        return await bookService.UpdateAsync(book);
    }
}