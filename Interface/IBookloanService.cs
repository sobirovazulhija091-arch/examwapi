using ExamApi.Responses;
using ExamApi.Entites;
using ExamApi.DTOs;
namespace  ExamApi.Interface;
public interface IBookloanService
{
    Task<Response<string>> AddAsync(BookloanDto bookloan1);
    Task<Response<string>> UpdateAsync(int bookloanid,UpdateBookloanDto bookloan);
    Task<Response<string>> DeleteAsync(int bookloanid);
    Task<Response<Bookloan>> GetByIdAsync(int bookloanid); 
    Task<Response<List<Bookloan>>> GetAsync(); 
    Task<Response<Bookloan>> ReturnAsync(int bookloanid);
}