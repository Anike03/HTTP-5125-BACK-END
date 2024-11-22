using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q7Controller : ControllerBase
    {
        /// <summary>
        /// Time-Travels by adding or subtracting a number of days from the current date.
        /// </summary>

        /// <param name="numberOfDays">The number of days to add or subtract from the current date. A positive value moves to future. Whereas, a negative value moves to past.</param>
  
        /// <returns>Returns the resulting date after time travel in the format "yyyy-MM-dd".</returns>
        
        /// <example>
        /// GET http://localhost:xx/api/timemachine?numberOfDays=10
        /// Response: "2024-10-07"
        /// 
        /// GET http://localhost:xx/api/timemachine?numberOfDays=-10
        /// Response: "2024-09-17"
        /// </example>

        [HttpGet(template: "timemachine")]
        public string timemachine(int numberOfDays)                       /// processes the numbers of days to travel in future or past.
        {
            DateTime presentDate = DateTime.Now;                          /// processes the present date.
            DateTime TimetSkipped = presentDate.AddDays(numberOfDays);    /// skips the present date into future or past, exact the integer provided by user.
            return TimetSkipped.ToString("yyyy-MM-dd");                   ///response: returns the future or past date in yyyy-mm-dd format.
        }

    }
}
