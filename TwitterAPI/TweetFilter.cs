using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TwitterAPI
{
    public class TweetFilter
    {
        public String Username { get; set; }

        public String Since { get; set; }

        public String Until { get; set; }

        public String QuerySearch { get; set; }

        public int MaxTweets { get; set; }
    }
}
