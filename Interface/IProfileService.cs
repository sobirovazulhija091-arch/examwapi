using ExamApi.Responses;
using ExamApi.Entites;
using ExamApi.DTOs;
namespace  ExamApi.Interface;
public interface IProfileService
{
   Task<Response<string>> Add(int userId,string Name);
   Task<Response<List<Profile>>> GetAll();
}