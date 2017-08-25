using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = TweetManager.GetTweets(new TweetFilter() {QuerySearch = "#SpbDotNet"}).Result;

            Console.ReadLine();
        }
    }
}
