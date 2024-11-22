using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q6Controller : ControllerBase
    {

        /// <summary>
        /// Calculates the hexagon area by the given length of one of its sides.
        /// </summary>

        /// <param name="sideLength">The length of one side of the hexagon. Must be a positive number.</param>

        /// <returns>The area of the hexagon calculated using the formula: (3 * Math.Sqrt(3) * sideLength * sideLength) / 2.</returns>

        /// <example>
        /// GET http://localhost:XX/api/Q6/hexagonside?sideLength=1
        /// Response: 2.598076211353316
        /// </example>
        /// 


        ///GET http://localhost:XX/api/Q6/hexagonside?sideLength=1
        [HttpGet(template: "hexagonside")]
        public double Q6(double sideLength)                 /// processes the input sideLength
        {
            double hexagonarea = (3 * Math.Sqrt(3) * sideLength * sideLength) /2;       ///calculates the area and applies the formula of a regular hexagon based on the provided length of one of its sides.

            return hexagonarea;       /// returns the area of a regular hexagon based on the provided length of one of its sides.

        }


    }
}
