using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

// Author: Kathleen West, http://www.katiegirl.net
// Description:
// This is a simple service application that accepts a user's name
// and age then outputs six lucky lottery numbers.
// The lucky numbers are based on the user's age, today's date,
// a random number generator, and most frequent powerball number is 20
// Note: The maximum PowerBall number is 69


namespace myWebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {

        LuckyLotteryNumbersService numbers = new LuckyLotteryNumbersService();

        // GET api/values
        public string Get()
        {
            return numbers.CalculateLuckyLotteryNumbers("Stranger without a Name", 36);
        }

        // GET api/values/5
        public string Get(string name,int age)
        {
            return numbers.CalculateLuckyLotteryNumbers(name, age);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

 
    public class LuckyLotteryNumbersService
    {
        StringBuilder sb;
        DateTime date;
        string format;
        Random number;

        public string CalculateLuckyLotteryNumbers(string name, int age)
        {

            sb = new StringBuilder();   // object to hold the string
            date = DateTime.Now;        // Today's DateTime
            format = " ";               // For string formatting
            number = new Random();      // Random Number

            // Creates the Welcome String      
            sb.Append("Hello, ");
            sb.Append(name);
            sb.Append(". Your input age is: ");
            sb.Append(age);
            sb.Append(". Your lucky lottery numbers are: ");

            if (age >= 2 && age <= 125)
            {
                // First Number
                // The most frequent powerball number is actually 20
                sb.Append("20");
                sb.Append(format);

                // Second Number
                sb.Append(69 % age);
                sb.Append(format);

                // Third Number
                sb.Append(date.Month);
                sb.Append(format);

                // Fourth Number
                sb.Append(date.Second > 0 ? date.Second : 1);
                sb.Append(format);

                // Fifth Number
                sb.Append(number.Next(1, 69));
                sb.Append(format);

                // Sixth Number
                sb.Append(date.Year - 2000 < 69 ? date.Year - 2000 : number.Next(1, 69));
                sb.Append(format);

                // Return the String
                return sb.ToString();
            }

            // Age is out of norm
            throw new Exception("Invalid Input Parameters Age (2 < Age < 125)");

        }

    }

}
