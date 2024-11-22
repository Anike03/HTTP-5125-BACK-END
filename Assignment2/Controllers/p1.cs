using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : Controller
    {

        /// <summary>
        /// Calculates the total score based on deliveries and collisions.
        /// </summary> 
        /// <param name="deliveries">The count of successful deliveries completed by the droid.</param> 
        /// <param name="collisions">The count of collisions the droid encountered.</param>
        /// <remarks>
        /// Each successful delivery awards 50 points, while each collision deducts 10 points.
        /// Additionally, if deliveries exceed collisions, a bonus of 500 points is applied to the final score.
        /// </remarks> 
        /// <returns>The total score after calculating points from deliveries and penalties from collisions.</returns>
        /// <example>
        /// Example input: deliveries = 10, collisions = 2
        /// Example output: Total score = 500 + (10 * 50) - (2 * 10) = 500 + 500 - 20 = 980
        /// </example>
        [HttpPost(template: "delevedroid")]
        public int delevedroid([FromForm] int deliveries, [FromForm] int collisions)
        {
            /// Initialize total score
            int total = 0;
            /// Calculate points from deliveries (50 points per delivery)
            int del = deliveries * 50;
            /// Calculate penalty from collisions (10 points deducted per collision)
            int col = collisions * 10;
            /// Calculate initial total
            total = del - col;
            /// If the number of deliveries is greater than collisions, add a bonus of 500 points
            if (deliveries > collisions)
                if (deliveries > collisions)
            {
                total = total + 500; /// Add bonus points
                }
            /// Return the final total score
            return total;
        }
    }
}
