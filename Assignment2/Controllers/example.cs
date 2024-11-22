using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class exampleController : ControllerBase
    {
        /// <summary>
        /// Calculates the total spice level based on the provided chili pepper ingredients.
        /// </summary>
        /// <param name="ingredients">A comma-separated string of chili pepper names.</param>
        /// <returns>
        /// The total spice level calculated from the specified ingredients.
        /// If the input is invalid or contains unknown peppers, -1 is returned.
        /// </returns>
        /// <remarks>
        /// Valid pepper names include: Poblano, Mirasol, Serrano, Cayenne, Thai, and Habanero.
        /// </remarks>
        /// <example>
        /// Example input: "Poblano, Serrano, Habanero"
        /// Example output: 126500
        /// Calculation: 1500 (Poblano) + 15500 (Serrano) + 125000 (Habanero) = 126500
        /// </example>
        [HttpGet("chilipeppers")]
        public int CalculateTotalSpiceLevel(string ingredientList)
        {
            // Define a dictionary to store the spice levels of different peppers
            var spiceLevelsByPepper = new Dictionary<string, int>
            {
                { "Poblano", 1500 },
                { "Mirasol", 6000 },
                { "Serrano", 15500 },
                { "Cayenne", 40000 },
                { "Thai", 75000 },
                { "Habanero", 125000 }
            };

            // Check if the ingredients string is null or empty
            if (string.IsNullOrWhiteSpace(ingredientList))
            {
                return -1; // Return -1 to indicate invalid input
            }

            // Split, trim, and validate the peppers using LINQ
            var spiceLevels = ingredientList
                .Split(',')
                .Select(pepperName => pepperName.Trim())
                .Select(pepperName =>
                {
                    return spiceLevelsByPepper.TryGetValue(pepperName, out int spiceLevel) ? (int?)spiceLevel : null;
                })
                .ToList();

            // Return -1 if any pepper was invalid, otherwise return the total spice level
            return spiceLevels.Contains(null) ? -1 : spiceLevels.Sum() ?? 0;
        }
    }
}
