using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q4Controller : ControllerBase
    {
        /// <summary>
        /// Initiates a knock-knock joke by asking "Who's there?".
        /// </summary>

        /// <returns>A string that responds with "Who's there?" when the endpoint is called.</returns>

        /// <example>
        /// POST http://localhost:xx/api/Q4/ask -> "Who's there?"
        /// </example>

        ///POST : http://localhost:xx/api/Q4/knockknock -> "Who's there? "
        [HttpPost(template: "ask")]
        public string knockknock()  /// this handle a POST request to the endpoint defined by the [HttpPost(template: "ask")]. 
        {
            return "Who's there?";  /// return statement of the knockknock: "Who's there?".

        }
    }
}
