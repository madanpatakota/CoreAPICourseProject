using Microsoft.AspNetCore.Mvc;


namespace CoreAPI.Controllers
{
    //localhost:3000/products
    //https//:localhost:5097/api/Test


    //localhost:3000/weatherCast
    //[ApiController]
    //[Route("[controller]")] // WeatherForecast
    ////Route : to create the connection b/w the client and server.
    //                         (resource)
    //https//:localhost:5097/api/Test (URI)
    //Atual real HTTPGet
    //https//:localhost:5097/api/Test/Getcustomers (URI)
    //protocol:domain name  /______________________


    //https://localhost:7078/api/Test
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        //https://localhost:7078/api/Test/GetStudents
        [Route("GetStudents")]
        [HttpGet]
        public IActionResult GetStudents()
        {
            // i need to connect the DB . EF
            return Ok(new string[] { "John", "Robert" });
        }


        //https://localhost:7078/api/Test/GetCourses
        [Route("GetCourses")]
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(new string[] { "Csharp", "Asp.netCore" });
        }
    }
}
