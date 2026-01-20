using System.Text.Json.Serialization;

namespace ExamApi.Entites;
 
 public class User
 {
 public int Id{get;set;}
 public string FullName{get;set;}=null!;
 public string Email{get;set;}=null!;
 public DateTime RegisteredAt{get;set;}=DateTime.UtcNow;
   [JsonIgnore]
 public Profile? Profile {get; set;}
public List<Bookloan> Bookloans{get;set;}=[];
}

