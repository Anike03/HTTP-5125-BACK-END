using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///This is the Q2Controller, which handles requests and responses,including provided name.
    public class Q2Controller : ControllerBase
    {
        ///<summary>
        ///Returns a friendly greeting with the name provided.
        ///</summary>

        ///<param name="name">The person's name that you want to greet. This is passed as a query parameter.</param> 
        ///<returns>A greeting message in the format "Hi {name}!". If the name contains URL-encoded characters, they will be decoded.</returns>
        ///<remark>A message like "Hi {name}!". Any special characters in the name (like URL encoding) will be cleaned up.</remark>

        ///<example>
        ///GET http://localhost:xx/api/Q2/greeting?name=Gary -> "Hi Gary!"
        ///GET http://localhost:xx/api/Q2/greeting?name=Ren%C3%A9e -> "Hi Renée!"
        ///</example>

        [HttpGet(template:"greeting")]
        public string Q2( string name)               ///Construct the greeting message using the query string value.
        {
            return "Hi" + " "+ name +"!";            ///Response: "Hii(provided name)!"
        }
    
    }

}