using ExamApi.Responses;
using ExamApi.Entites;
namespace  ExamApi.Interface;
public interface IBookloanService
{
    Task<Response<string>> AddAsync(Bookloan bookloan);
    Task<Response<string>> UpdateAsync(Bookloan bookloan);
    Task<Response<string>> DeleteAsync(int bookloanid);
    Task<Response<Bookloan>> GetByIdAsync(int bookloanid); 
    Task<List<Bookloan>> GetAsync(); 


}