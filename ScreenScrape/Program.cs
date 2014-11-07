using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScreenScrape
{
    class Program
    {
        
        private static List<string> a = new List<string>();
        static void Main(string[] args)
        {
            MatchSite matchSite = new MatchSite();
            var linkList = matchSite.GetLinks("http://www.picknpay.co.za/");
            
            // The following lines of code writes the extracted Urls to the file named test.txt
            StreamWriter sw = new StreamWriter(System.IO.Path.GetFullPath("test.txt"));
            sw.Write(urlListString);
            sw.Close(); 
            Console.ReadLine();
        }
    }
}
