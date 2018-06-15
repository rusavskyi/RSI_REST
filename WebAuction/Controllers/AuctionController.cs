using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAuction.Models;

namespace WebAuction.Controllers
{
    public class AuctionController : Controller
    {
        private string _baseAddress = "http://localhost:65322/Auction.svc/";

        // GET: Auction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Auction
        public async Task<ActionResult> AllLots()
        {
            List<Lot> lots = new List<Lot>();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseAddress);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync("alllots");

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    //StringReader reader = new StringReader(result);
                    //XmlSerializer serializer = new XmlSerializer(typeof(List<Lot>));
                    //lots = (List<Lot>)serializer.Deserialize(reader);
                    lots = JsonConvert.DeserializeObject<List<Lot>>(result);
                }

                return View(lots);
            }

        }

        // GET: Auction
        public async Task<ActionResult> Lot(int? id)
        {
            Lot lot = new Lot();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseAddress);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync("alllots/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    //StringReader reader = new StringReader(result);
                    //XmlSerializer serializer = new XmlSerializer(typeof(Lot));
                    //lots = (List<Lot>)serializer.Deserialize(reader);
                    lot = JsonConvert.DeserializeObject<Lot>(result);
                }

            }
            return View(lot);
        }

        public async Task<ActionResult> PlaceBet(Lot lot)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseAddress);
                var sendLot = JsonConvert.SerializeObject(lot);
                HttpContent content = new StringContent(sendLot, System.Text.Encoding.UTF8, "application/json");
                var res = await httpClient.PutAsync("/Auction.svc/alllots/" + lot.Id, content);

                Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!" + res.Content.ReadAsStringAsync().Result);
            }
            return View("Index");
        }


        public ActionResult Create()
        {

            return View();
        }

        public async Task<ActionResult> CreateForm(Lot lot)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseAddress);
                var sendLot = JsonConvert.SerializeObject(lot);
                HttpContent content = new StringContent(sendLot, System.Text.Encoding.UTF8, "application/json");
                var res = await httpClient.PutAsync("/Auction.svc/alllots", content);

                //Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!" + res.Content.ReadAsStringAsync().Result);
            }
            return View("Index");
        }
    }
}