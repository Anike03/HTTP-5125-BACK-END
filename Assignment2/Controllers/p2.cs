using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Determines Barley's happiness based on the number and size of treats he receives.
        /// </summary>
        /// <param name="s">The number of small treats Barley receives (1 point each).</param>
        /// <param name="m">The number of medium treats Barley receives (2 points each).</param>
        /// <param name="l">The number of large treats Barley receives (3 points each).</param>
        /// <remarks>
        /// The total happiness score is calculated as:
        /// - Small treats add 1 point each,
        /// - Medium treats add 2 points each,
        /// - Large treats add 3 points each.
        /// If Barley's happiness score is 10 or greater, he is considered "Happy"; otherwise, he is "Sad."
        /// </remarks>
        /// <returns>A string indicating whether Barley is "Happy" or "Sad" based on his total happiness score.</returns>
        /// <example>
        /// Example input: s = 3, m = 2, l = 1
        /// Example output: "Happy"
        /// Calculation: (1 * 3) + (2 * 2) + (3 * 1) = 3 + 4 + 3 = 10
        /// </example>
        
        [HttpPost(template: "dogtreats")]
        public string dogtreats([FromForm] int s, [FromForm] int m, [FromForm] int l)
        {
            /// Calculate total happiness score
            /// Small treats add 1 point, medium treats add 2 points, and large treats add 3 points
            int total = (1 * s) + (2 * m) + (3 * l);

            /// Check if Barley is happy or sad
            if (total >= 10)
            {
                return "Happy";  /// happy
            }
            else
            {
                return "Sad";    /// sad
            }
        }
    }
}