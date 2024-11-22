using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ASSIGNMENT1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q8Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the total cost for small and large items, including tax.
        /// </summary>

        /// <param name="smallItems">The number of small items purchased.</param>
        /// <param name="largeItems">The number of large items purchased.</param>

        /// <returns>A formatted string detailing the cost breakdown, including item totals, subtotal, tax, and total amount.</returns>
       
        /// <example>
        /// POST http://localhost:xx/api/Q8/squashfellows 
        /// Content-Type: application/x-www-form-urlencoded 
        /// smallItems=2&largeItems=3 
        /// Response: "2 small@ 25.50 = $51.00; 3 Large@ 40.50 = $121.50; Subtotal = $172.50; Tax = $22.43; Total = $194.93"
        
        [HttpPost(template: "squashfellows")]
        public string squashfellows([FromForm] int smallItems, [FromForm] int largeItems)

        {

            /// Prices and tax rate
            double smallItemtotal = smallItems * 25.50;
            double largeItemtotal = largeItems * 40.50;
            double hstrate = 0.13;

            /// Calculate subtotal
            double subtotal = smallItemtotal + largeItemtotal;

            /// Calculate tax
            double tax = Math.Round(subtotal * hstrate, 2);

            /// Calculate total
            double total = subtotal + tax;


             /// represents the culture and formatting conventions for Canadian English.
             /// whereas en stands for english and capital CA stands for Canada.
             var canadianculture = new CultureInfo("en-CA");

            /// Here,C2 is a format specifier whereas,C: Stands for "Currency."and 2:Indicates the number of decimal places to display
            /// This line formats the smallItemTotal value 
            string formattedSmallTotal = smallItemtotal.ToString("C2", canadianculture);

            /// This line formats the largeItemTotal value
            string formattedLargeTotal = largeItemtotal.ToString("C2", canadianculture);

            ///This line formats the SubTotal value
            string formattedSubtotal = subtotal.ToString("C2",canadianculture);

            /// This line formats the Tax value
            string formattedTax = tax.ToString("C2", canadianculture);

            ///This line formats the Total value
            string formattedTotal = total.ToString("C2", canadianculture);
            
            /// response: quantity of small + quantity of large which is subtotal + tax = total value(en-CA)
            return $"{smallItems} small@ 25.50 = {formattedSmallTotal};" +
                   $"{largeItems} Large@ 45.50 = {formattedLargeTotal};" +
                   $"Subtotal = {formattedSubtotal};" +
                   $"Tax = {formattedTax};" +
                   $"Total = {formattedTotal}";
        }

    }
}
