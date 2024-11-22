using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///This is the Q1Controller, which handles basic requests and responses, including a welcome message.
    public class Q1Controller : ControllerBase
    {
        ///<summary>
        ///A GET request to welcome the user to the system.
        ///</summary>

        ///<returns>
        ///A string message "Welcome to 5125!" which is a greeting message.
        ///</returns>

        ///<example>
        ///GET https://localhost:xx/api/Q1/welcome
        ///Response: "Welcome to 5125!"
        ///</example>

        [HttpGet(template:"welcome")]           ///GET https://localhost:xx/api/Q1/welcome ->  "Welcome to 5125!"
        public string welcome()
        {
            return "welcome to 5125!";          ///Response: "Welcome to 5125!"
        }
    }
}





