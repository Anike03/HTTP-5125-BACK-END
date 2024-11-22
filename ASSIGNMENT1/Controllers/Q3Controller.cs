using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q3Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the cube of the provided integer value.
        /// </summary>

        /// <param name="value">The integer value to be cubed.</param>
        
        /// <returns>The cube of the input integer.example the cube of 3 is 27 </returns>

        /// <example>
        /// GET http://localhost:xx/api/Q3/cube/4 -> 64
        /// GET http://localhost:xx/api/Q3/cube/-4 -> -64
        /// GET http://localhost:xx/api/Q3/cube/-10 -> 1000
        /// </example>

        [HttpGet(template: "cube/{value}")]
        public int Q3(int value)
        {
            int cubeResult = value * value * value;      /// Construct the cube of given value.
            return cubeResult;                          /// Response: cubic value either(-) or(+) of given integer value.
        }


    }
}
