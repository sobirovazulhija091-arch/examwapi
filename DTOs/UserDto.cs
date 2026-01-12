using System.ComponentModel.DataAnnotations;
namespace ExamApi.DTOs;
public class UserDto
{
    [Required]
    public string FullName{get;set;}=null!;
    [Required]
    public string Email{get;set;}=null!;
}