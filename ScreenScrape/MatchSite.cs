using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScreenScrape
{
    public class MatchSite
    {
        //public string get

        public Dictionary<string, string> GetLinks(string url)
        {
            Dictionary<string, string> urlList = new Dictionary<string, string>();
            // make an object of the WebClient class 
            WebClient objWebClient = new WebClient();
            // gets the HTML from the url written in the textbox
            var aRequestHTML = objWebClient.DownloadData(url);
            // creates UTf8 encoding object
            UTF8Encoding utf8 = new UTF8Encoding();
            // gets the UTF8 encoding of all the html we got in aRequestHTML
            var inputString = utf8.GetString(aRequestHTML);
            // this is a regular expression to check for the urls
            string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";
            var match = Regex.Match(inputString, HRefPattern,
                     RegexOptions.IgnoreCase | RegexOptions.Compiled,
                     TimeSpan.FromSeconds(1));

            // get all the matches depending upon the regular expression
            var urlListString = "";
            while (match.Success)
            {
                if (!urlList.Keys.Contains(match.Groups[1].ToString()))
                {
                    urlList.Add(match.Groups[1].ToString(), match.Groups[1].ToString());
                    Console.WriteLine("Found href " + match.Groups[1] + " at " + match.Groups[1].Index);
                    urlListString += match.Groups[1].ToString() + "\n";
                }
                match = match.NextMatch();
            }
            return urlList;
        }

        public string GetEntireSiteLinks(string siteName)
        {
            return "true";
        }
    }
}
