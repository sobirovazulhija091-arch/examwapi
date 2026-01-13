using System.ComponentModel.DataAnnotations;
namespace ExamApi.DTOs;
public class UpdateUserDto
{
    [Required]
     public int Id{get;set;}
    [Required]
 public string FullName{get;set;}=null!;
    [Required]
 public string Email{get;set;}=null!;

}