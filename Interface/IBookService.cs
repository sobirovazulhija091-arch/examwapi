using ExamApi.Responses;
using ExamApi.Entites;
namespace  ExamApi.Interface;
public interface IBookService
{
    Task<Response<string>> AddAsync(Book book);
    Task<Response<string>> UpdateAsync(Book book);
    Task<Response<string>> DeleteAsync(int bookid);
    Task<Response<Book>> GetByIdAsync(int bookid); 
    Task<List<Book>> GetAsync(); 


}