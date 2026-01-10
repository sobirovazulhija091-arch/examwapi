using ExamApi.Responses;
using ExamApi.Entites;
namespace  ExamApi.Interface;
public interface IUserService
{
    Task<Response<string>> AddAsync(User user);
    Task<Response<string>> UpdateAsync(User user);
    Task<Response<string>> DeleteAsync(int  userid);
    Task<Response<User>> GetByIdAsync(int  userid); 
    Task<List<User>> GetAsync(); 


}