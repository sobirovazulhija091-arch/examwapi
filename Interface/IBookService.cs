using ExamApi.Responses;
using ExamApi.Entites;
using ExamApi.DTOs;
namespace  ExamApi.Interface;
public interface IBookService
{
    Task<Response<string>> AddAsync(BookDto book1);
    Task<Response<string>> UpdateAsync(int bookid,UpdateBookDto book);
    Task<Response<string>> DeleteAsync(int bookid);
    Task<Response<Book>> GetByIdAsync(int bookid); 
     Task<Response<List<Book>>> GetAsync(); 

}