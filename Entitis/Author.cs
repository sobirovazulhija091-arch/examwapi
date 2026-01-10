 namespace ExamApi.Entites;
public class Author{
public int Id{get;set;}
public string FullName{get;set;}=null!;
public DateOnly BirthDate{get;set;} 
public  string Country{get;set;}=null!; 
}