using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace  ExamApi.DTOs;
public class BookDto
{
    [Required]
public string Title{get;set;}=null!;
    [Required]
public int PublishedYear{get;set;}
    [Required]
public string Genre{get;set;}=null!;
    [Required]
public int AuthorId{get;set;} 
}