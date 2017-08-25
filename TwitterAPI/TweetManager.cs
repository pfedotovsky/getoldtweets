using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace TwitterAPI
{
    public class TweetManager
    {
        private static async Task<string> GetUrlResponse(String username, String since, String until,
            String querySearch)
        {
            String appendQuery = "";
            if (username != null)
            {
                appendQuery += "from:" + username;
            }

            if (since != null)
            {
                appendQuery += " since:" + since;
            }

            if (until != null)
            {
                appendQuery += " until:" + until;
            }

            if (querySearch != null)
            {
                appendQuery += " " + querySearch;
            }

            String url =
                $"https://twitter.com/i/search/timeline?f=realtime&q={HttpUtility.UrlEncode(appendQuery)}&src=typd";


            HttpClient httpClient = new HttpClient();

            return await httpClient.GetStringAsync(url);
        }

        public static async Task<List<Tweet>> GetTweets(TweetFilter tweetFilter)
        {
            List<Tweet> results = new List<Tweet>();

            try
            {
                outerLace:
                while (true)
                {
                    string rawResponse = await GetUrlResponse(tweetFilter.Username, tweetFilter.Since,
                        tweetFilter.Until, tweetFilter.QuerySearch);
                    
                    JObject json = JObject.Parse(rawResponse);

                    string itemsHtml = (string)json["items_html"];

                    HtmlDocument htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(itemsHtml);

                    HtmlNode tweets = htmlDocument.GetElementbyId("div.js-stream-tweet");

                    foreach (HtmlNode tweetsChildNode in tweets.ChildNodes)
                    {
                        //String usernameTweet = tweet.select("span.username.js-action-profile-name b").text();
                        //String txt = tweet.select("p.js-tweet-text").text().replaceAll("[^\\u0000-\\uFFFF]", "");
                        //int retweets = Integer.valueOf(tweet
                        //    .select("span.ProfileTweet-action--retweet span.ProfileTweet-actionCount")
                        //    .attr("data-tweet-stat-count").replaceAll(",", ""));
                        //int favorites = Integer.valueOf(tweet
                        //    .select("span.ProfileTweet-action--favorite span.ProfileTweet-actionCount")
                        //    .attr("data-tweet-stat-count").replaceAll(",", ""));
                        //long dateMs = Long.valueOf(tweet.select("small.time span.js-short-timestamp")
                        //    .attr("data-time-ms"));
                        //String id = tweet.attr("data-tweet-id");
                        //String permalink = tweet.attr("data-permalink-path");

                        //String geo = "";
                        //Elements geoElement = tweet.select("span.Tweet-geo");
                        //if (geoElement.size() > 0)
                        //{
                        //    geo = geoElement.attr("title");
                        //}

                        //Date date = new Date(dateMs);

                        //Tweet t = new Tweet();
                        //t.setId(id);
                        //t.setPermalink("https://twitter.com" + permalink);
                        //t.setUsername(usernameTweet);
                        //t.setText(txt);
                        //t.setDate(date);
                        //t.setRetweets(retweets);
                        //t.setFavorites(favorites);
                        //t.setMentions(processTerms("(@\\w*)", txt));
                        //t.setHashtags(processTerms("(#\\w*)", txt));
                        //t.setGeo(geo);

                        //results.add(t);

                        //if (tweetFilter.MaxTweets > 0 && results.size() >= tweetFilter.MaxTweets())
                        //{
                        //    break outerLace;
                        //}
                    }
                }
            }
            catch (Exception e)
            {
            }

            return results;
        }

        //private static String ProcessTerms(String patternS, String tweetText)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    Matcher matcher = Pattern.compile(patternS).matcher(tweetText);
        //    while (matcher.find())
        //    {
        //        sb.append(matcher.group());
        //        sb.append(" ");
        //    }

        //    return sb.toString().trim();
        //}
    }
}
