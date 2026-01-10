using ExamApi.Responses;
using ExamApi.Entites;
namespace  ExamApi.Interface;
public interface IAuthorService
{
    Task<Response<string>> AddAsync(Author author);
    Task<Response<string>> UpdateAsync(Author author);
    Task<Response<string>> DeleteAsync(int authorid);
    Task<Response<Author>> GetByIdAsync(int authorid); 
    Task<List<Author>> GetAsync(); 


}