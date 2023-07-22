using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        // Console.WriteLine(config.GetConnectionString("DefalultConnection"));
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("GetUsers/{testValue}")]
    public string[] GeUserst(string testValue)
    {
        return new string[] {"Trishten", "Lity", testValue};
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }
}
