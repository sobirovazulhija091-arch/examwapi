using System.Net;
using ExamApi.Entites;
using Dapper;
using Npgsql;
using ExamApi.Interface;
using ExamApi.Responses;
using ExamApi.DTOs;
using Microsoft.EntityFrameworkCore;

public class ProfileService(ApplicationDbContext dbContext) : IProfileService
{
    private readonly ApplicationDbContext context=dbContext;
    public async Task<Response<string>> Add(int userId,string Name)
    {
         Profile profile = new Profile(){UserId = userId,Nameprofile=Name};
        context.Profiles.Add(profile);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "added");
    }
    public async Task<Response<List<Profile>>> GetAll()
    {
        return new Response<List<Profile>>(HttpStatusCode.OK, "ok", context.Profiles.ToList());
    }
}