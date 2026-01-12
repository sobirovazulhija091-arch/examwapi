using ExamApi.Responses;
using ExamApi.Entites;
using ExamApi.DTOs;
namespace  ExamApi.Interface;
public interface IBookloanService
{
    Task<Response<string>> AddAsync(BookloanDto bookloan1);
    Task<Response<string>> UpdateAsync(Bookloan bookloan);
    Task<Response<string>> DeleteAsync(int bookloanid);
    Task<Response<Bookloan>> GetByIdAsync(int bookloanid); 
    Task<List<Bookloan>> GetAsync(); 
    Task<Response<Bookloan>> ReturnAsync(int bookloanid);
}