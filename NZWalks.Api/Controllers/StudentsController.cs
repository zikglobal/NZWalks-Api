using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.Api.Controllers
{
    //https:localhost:portnumber/api/student
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Get:https:localhost:portnumber/api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Ruth", "Sunday", "Emma", "Sarah" };
            return Ok (studentNames);

        }
    }
}
