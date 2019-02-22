using API_LAB.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace API_LAB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetData");
        }

        public ActionResult GetData()
        {
            List<JToken> titles = Data();
            List<JToken> thumbs = Thumbs();
            List<JToken> urls = URLS();

            ViewBag.Titled = titles;
            ViewBag.Thumbs = thumbs;
            ViewBag.URL = urls;
            return View();
        }

        public List<JToken> Data()
        {
            string URL = "http://www.reddit.com/r/aww/.json";
            HttpWebRequest request = WebRequest.CreateHttp(URL);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string ApiText = rd.ReadToEnd();

            JToken datad = JToken.Parse(ApiText);

            List<JToken> title = new List<JToken>();

            for (int i = 0; i < 10; i++)
            {
                title.Add(datad["data"]["children"][i]["data"]["title"]);
            }
            return title;
        }

        public List<JToken> Thumbs()
        {
            string URL = "http://www.reddit.com/r/aww/.json";
            HttpWebRequest request = WebRequest.CreateHttp(URL);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string ApiText = rd.ReadToEnd();

            JToken datad = JToken.Parse(ApiText);

            List<JToken> thumbnail = new List<JToken>();

            for (int i = 0; i < 10; i++)
            {
                thumbnail.Add(datad["data"]["children"][i]["data"]["thumbnail"]);
            }
            return thumbnail;
        }

        public List<JToken> URLS()
        {
            string URL = "http://www.reddit.com/r/aww/.json";
            HttpWebRequest request = WebRequest.CreateHttp(URL);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string ApiText = rd.ReadToEnd();

            JToken datad = JToken.Parse(ApiText);

            List<JToken> URLs = new List<JToken>();

            for (int i = 0; i < 10; i++)
            {
                URLs.Add(datad["data"]["children"][i]["data"]["url"]);
            }
            return URLs;
        }
    }
}
 //[JSON].data.children.[0].data.title