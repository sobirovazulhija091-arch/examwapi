using System.ComponentModel.DataAnnotations;
namespace ExamApi.DTOs;
public class UpdateAuthorDto
{
    [Required]
    public int Id{get;set;}
    [Required]
    public string FullName{get;set;}=null!;
    [Required]
     public int BirthDate{get;set;} 
     [Required]
     public  string Country{get;set;}=null!; 
}