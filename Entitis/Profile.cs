
using System.Text.Json.Serialization;

namespace ExamApi.Entites;

public class Profile
{
    public int Id{get;set;}
    public int UserId{get;set;}
    public string Nameprofile{get;set;}=null!;
     [JsonIgnore]
    public User? User{get;set;}
}