using System;

namespace TwitterAPI
{
    public class Tweet
    {
        public String ID { get; set; }

        public String Permalink { get; set; }

        public String Username { get; set; }

        public String Text { get; set; }

        public DateTime Date { get; set; }

        public int Retweets { get; set; }

        public int Favorites { get; set; }

        public String Mentions { get; set; }

        public String Hashtags { get; set; }

        public String Geo { get; set; }
    }
}
