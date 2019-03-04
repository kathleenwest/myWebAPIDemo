# myWebAPIDemo

Project Blog Site: https://portfolio.katiegirl.net/2017/11/09/lucky-lottery-numbers-a-simple-asp-net-web-api/

My Web API Demo:

This is a simple ASP.NET Web API that also demonstrates a RESTful api. It will calculate and return lucky lottery numbers based on either a default (api/values/) or custom HTTP Get Request (example: values?name=Kathleen&age=36) with TWO input parameters in the request.

A RESTful API is an application program interface (API) that uses HTTP requests to GET, PUT, POST and DELETE data. A web API is an application programming interface (API) for either a web server or a web browser. ASP.NET Web API is a framework that makes it easy to build HTTP services that reach a broad range of clients, including browsers and mobile devices. ASP.NET Web API is an ideal platform for building RESTful applications on the .NET Framework.

Samples:
ValuesController.cs
Pictures:
Web Application Screen
Default Response
Custom Response
Planned Exception Handling
Visual Studio Solution: myWebAPIDemo_VSS.zip

How to Access API

default (http://...../api/values/)

custom HTTP Get Request (example: http://....../values?name=Kathleen&age=36) 

Controller Code
```
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
```
