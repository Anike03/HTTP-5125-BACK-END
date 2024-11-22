using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J5Controller : ControllerBase
    {
        /// <summary>
        /// Checks if the given date is before, after, or on February 18.
        /// </summary>
        /// <param name="input">An object containing the month and day of the date to check.</param>
        /// <returns>
        /// A string indicating the result:
        /// - "Before" if the date is before February 18,
        /// - "Special" if the date is February 18,
        /// - "After" if the date is after February 18.
        /// </returns>
        /// <example>
        /// Example input: { "Month": 2, "Day": 18 }
        /// Example output: "Special"
        
        /// Example input: { "Month": 2, "Day": 17 }
        /// Example output: "Before"
        
        /// Example input: { "Month": 2, "Day": 19 }
        /// Example output: "After"
        /// </example>
        [HttpPost("SpecialDay")]
        public string CheckDate([FromBody] DateInput input)
        {
            int specialMonth = 2;
            int specialDay = 18;

            // Check the date and return appropriate string result
            if (input.Month < specialMonth || (input.Month == specialMonth && input.Day < specialDay))
            {
                return "Before";
            }
            else if (input.Month == specialMonth && input.Day == specialDay)
            {
                return "Special";
            }
            else
            {
                return "After";
            }
        }
    }

    /// Represents the input data for checking a date.
    public class DateInput
    {
        /// Gets or sets the month of the date (1-12).
        public int Month { get; set; }

        /// Gets or sets the day of the date (1-31).
        public int Day { get; set; }
    }
}
