using ExamApi.Responses;
using ExamApi.Entites;
using ExamApi.DTOs;
namespace  ExamApi.Interface;
public interface IAuthorService
{
    Task<Response<string>> AddAsync(AuthorDto author1);
    Task<Response<string>> UpdateAsync(int authorid,UpdateAuthorDto author1);
    Task<Response<string>> DeleteAsync(int authorid);
    Task<Response<Author>> GetByIdAsync(int authorid); 
     Task<Response<List<Author>>> GetAsync();


}