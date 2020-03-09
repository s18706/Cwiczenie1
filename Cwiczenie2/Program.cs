using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //int tmp1 = 1;
            //double tmp2 = 2.0;

            //string tmp3 = "Ala ma kota";
            //bool tmp4 = true;

            //var tmp5 = "i psa";

            //var path = @"c:\users\s18706\desktop\cw1";
            //Console.writeline($"{tmp3} {tmp5} {tmp1 + tmp2}");

            //var newperson = new Person { FirstName = "daniel" };
            //ctrl + k + c => komentowanie, ctrl + k + u => odkomentowanie

            var url = args.Length > 0 ? args[0] : "http://www.pja.edu.pl";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
            }

            //var httpClient = new HttpClient();


        }
    }
}
