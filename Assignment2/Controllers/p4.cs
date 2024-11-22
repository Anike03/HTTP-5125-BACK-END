using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J4Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the number of leftover cupcakes after distributing them to students.
        /// </summary>
        /// <param name="regularBoxes">The number of regular boxes of cupcakes, where each box holds 8 cupcakes.</param>
        /// <param name="smallBoxes">The number of small boxes of cupcakes, where each box holds 3 cupcakes.</param>
        /// <returns>
        /// A string that includes the total number of leftover cupcakes after each of the 28 students has received one cupcake.
        /// If the total number of cupcakes is less than the number of students, the returned value will indicate a negative number of leftovers.
        /// </returns>
        /// <example>
        /// Example input: regularBoxes = 2, smallBoxes = 3
        /// Example output: "Total is 5"
        /// Calculation: (2 * 8) + (3 * 3) = 16 + 9 = 25; 25 - 28 = -3
        /// </example>
        [HttpGet("Cupcake Party")]
        public string GetLeftoverCupcakes(int regularBoxes, int smallBoxes)
        {
            // Define the number of cupcakes per box
            const int cupcakesInRegularBox = 8;
            const int cupcakesInSmallBox = 3;
            const int numberOfStudents = 28;

            // Calculate total cupcakes
            int totalCupcakes = (regularBoxes * cupcakesInRegularBox) + (smallBoxes * cupcakesInSmallBox);

            // Calculate leftover cupcakes
            int leftoverCupcakes = totalCupcakes - numberOfStudents;

            // Return the leftover cupcakes
            return $"Total is {leftoverCupcakes}";
        }
    }
}


