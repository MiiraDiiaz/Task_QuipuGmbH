using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_QuipuGmbH
{
    class Model
    {
        public string[] FileReaderUrl()
        {
            string[] readUrl=null;
            string path = @"C:\Users\User\source\repos\Task_QuipuGmbH\Task_QuipuGmbH\bin\Debug\UrlList.txt";
      
            readUrl = File.ReadAllLines(path);
     
            return readUrl;           
        }
        public int NamberOfTags(string url)
        {
            int numberOfTags=0;
            string htmlText = GetHtmlText(url);

            Regex regex = new Regex(@"</a>");
            MatchCollection matches = regex.Matches(htmlText);
            numberOfTags=matches.Count;

            return numberOfTags;
        }
        public string GetHtmlText(string url)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            int count = 0;

            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    sb.Append(Encoding.Default.GetString(buf, 0, count));
                }
            }
            while (count > 0);

            return sb.ToString();
        }
    }
}
