using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q5Controller : ControllerBase
    {
        /// <summary>
        /// Reveals a secret number provided in the request body.
        /// </summary>

        /// <param name="secretNumber">The secret number sent in [FromBody].</param>

        /// <returns>A string indicating the secret number.</returns>
        
        /// <example>
        /// POST http://localhost:xx/api/Q5/secret
        /// Request Body: 5
        /// Response: "Shh.. the secret number is 5"
        /// </example>  
        
        ///POST http://localhost:xx/api/Q5/secret -> "Shh.. the secret number is"
        [HttpPost(template: "secret")]
        public string Q5([FromBody] int secretNumber)                    ///this handle a POST request to the endpoint Q5([FromBody] int secretNumber). 
        {
            {
                return $"Shh.. the secret number is {secretNumber}";    /// This will respopnse:"Shh.. the secret number is 42".
                                                                        
            }
        }

    }
}




