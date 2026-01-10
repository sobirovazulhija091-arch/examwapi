using Npgsql;
namespace ExamApi.Data;
public class ApplicationDbContext
{
   
      private readonly string connString="Host=localhost;Port=5432;Database=exam;Username=postgres;Password=1234";
      public NpgsqlConnection Connection()=> new NpgsqlConnection(connString);
}
