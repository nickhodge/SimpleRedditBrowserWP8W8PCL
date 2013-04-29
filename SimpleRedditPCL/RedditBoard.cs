using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SimpleRedditPCL
{
    public class RedditBoard
    {
        public string Subreddit;
 
        public RedditBoard(string sr)
        {
            Subreddit = sr;
        }

        public async Task<JEnumerable<JToken>>GetData()
        {
            var wc = new HttpClient();
            var dt = await wc.GetStringAsync(String.Format("http://reddit.com/r/{0}.json",Subreddit));
            var ls = JObject.Parse(dt);
            return ls["data"]["children"].Children();
        }
    }

    public class subredditentries
    {
        private static DateTime unixDateTimeEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public string domain { get; set; }
        public string subreddit { get; set; }
        public string selftext_html { get; set; }
        public string selftext { get; set; }
        public string likes { get; set; }
        public string link_flair_text { get; set; }
        public string id { get; set; }
        public bool clicked { get; set; }
        public string title { get; set; }
        public int score { get; set; }
        public string approved_by { get; set; }
        public bool over_18 { get; set; }
        public bool hidden { get; set; }
        public string thumbnail { get; set; }
        public string subreddit_id { get; set; }
        public bool edited { get; set; }
        public int downs { get; set; }
        public bool saved { get; set; }
        public bool is_self { get; set; }
        public string permalink { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public long created_utc { get; set; }
        public int ups { get; set; }
        public int num_comments { get; set; }

        public string TitleClean
        {
            get { return WebUtility.HtmlDecode(title); }
        }

        public DateTime CreatedUTCTime
        {
            get
            {
                return unixDateTimeEpoch.AddSeconds(created_utc);
            }
        }

        public DateTime CreatedLocalTime
        {
            get
            {
                return unixDateTimeEpoch.AddSeconds(created_utc).ToLocalTime();
            }
        }


    }

}
