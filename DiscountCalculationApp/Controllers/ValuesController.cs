using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCalculationApp.Controllers
{
    // Please Refactor the Code as Required - use OOPS Concepts - Create Models,interface and classes as required
    // Create a Service Layer called DiscountCalculationService and Implement the Service using DI - Net Core DI 
    // Implement Stragery Pattern for making maintence of the code easily 
    // Use Constants to hold constant values
    // Add one more userType Normal-User and discountpercent allowed is 5  (if Time Permits)

    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCalculationController : ControllerBase
    {
      
        int bookCostPrice = 245;
        string bookName = "Cracking the Coding Test";
        int sellingprice = 0;

        public DiscountCalculationController()
        {
          
        }
        // GET api/values
        [HttpGet]
        public ActionResult<int> GetBookPrice(string userType)
        {                     
            sellingprice = ApplyDiscount(userType, bookCostPrice);
            return sellingprice;

        }

        private static int ApplyDiscount(string userType, int bookCostPrice)
        {
            int sellingPrice = 0;
            int discountpercent = 0;

            // Gold Member Discount
            if (userType == "GOLD")
            {
                discountpercent = 20;
            }
            else if (userType == "SILVER")
            {
                discountpercent = 15;
            }
            else if (userType == "Bronze")
            {
                discountpercent = 10;
            }

            sellingPrice = bookCostPrice - ((bookCostPrice * discountpercent) / 100);
            return sellingPrice;
        }
    }
}
