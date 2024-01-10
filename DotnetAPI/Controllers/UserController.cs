using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        System.Console.WriteLine(config.GetConnectionString("DefaultConnection"));
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers/{testValue}")]
    // public IActionResult Test() //! It's save to return anything using IActionResult
    public string[] GetUsers(string testValue)
    // 1. use it like this http://localhost:5162/user/test?testValue=%22torin%22 
    //      if [HttpGet("test")]
    //      %22torin%22 is actually "torin"
    // 2. use it like this http://localhost:5162/User/test/torinZhou
    //      if [HttpGet("test/{testValue}")]
    {
        var response = new string[] {
            "test1",
            "test2",
            testValue
        };
        return response;
    }

}

