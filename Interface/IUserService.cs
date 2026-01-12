using ExamApi.Responses;
using ExamApi.Entites;
using ExamApi.DTOs;
namespace  ExamApi.Interface;
public interface IUserService
{
    Task<Response<string>> AddAsync(UserDto user1);
    Task<Response<string>> UpdateAsync(User user);
    Task<Response<string>> DeleteAsync(int  userid);
    Task<Response<User>> GetByIdAsync(int  userid); 
    Task<List<User>> GetAsync(); 


}