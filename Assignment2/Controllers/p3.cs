using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
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
        public int ChiliPeppers(string ingredients)
        {
            // Define a dictionary to store the spice levels of different peppers
            var pepperSpiceLevels = new Dictionary<string, int>
            {
                { "Poblano", 1500 },
                { "Mirasol", 6000 },
                { "Serrano", 15500 },
                { "Cayenne", 40000 },
                { "Thai", 75000 },
                { "Habanero", 125000 }
            };

            // Check if the ingredients string is null or empty
            if (ingredients == null || ingredients.Trim() == "")
            {
                return -1; // Return -1 to indicate invalid input
            }

            // Initialize the total spice level to zero
            int totalSpice = 0;

            // Split the ingredients string into an array using commas
            string[] listPeppers = ingredients.Split(',');

            // Loop through each pepper in the list
            foreach (string pepper in listPeppers)
            {
                // Trim any extra spaces from the pepper name
                string trimmedPepper = pepper.Trim();

                // Check if the trimmed pepper name is in the dictionary
                if (pepperSpiceLevels.ContainsKey(trimmedPepper))
                {
                    // Add the spice level to the total
                    totalSpice += pepperSpiceLevels[trimmedPepper];
                }
                else
                {
                    // If the pepper is unknown, return -1
                    return -1; // Indicate an unknown pepper
                }
            }

            // Return the total spice level
            return totalSpice;
        }

    }
}














