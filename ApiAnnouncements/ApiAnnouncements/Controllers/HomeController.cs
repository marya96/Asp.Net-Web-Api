using ApiAnnouncements.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiAnnouncements.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            List<Announcement> announcements = new List<Announcement>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64556/");

                client.DefaultRequestHeaders.Clear();
                //Defien request data  format
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Resp = await client.GetAsync("api/Announcements");

                if (Resp.IsSuccessStatusCode)
                {
                    var announceResponse = Resp
                        .Content
                        .ReadAsStringAsync()
                        .Result;

                    announcements = JsonConvert.DeserializeObject<List<Announcement>>(announceResponse);
                }
            }

            return View(announcements);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            Announcement announcement = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64556/");

                client.DefaultRequestHeaders.Clear();
                //Defien request data  format
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var Resp =  client.GetAsync("api/Announcements?id=" + id.ToString());

           

                var result = Resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Announcement>();
                    readTask.Wait();

                    announcement = readTask.Result;

                }
            }
            return View(announcement);
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Announcement announcement)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64556/");

                client.DefaultRequestHeaders.Clear();
                //Defien request data  format
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var Resp =  client.PostAsJsonAsync<Announcement>("api/Announcements", announcement);

                var result = Resp.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(announcement);
        }


        //Edit
        public ActionResult Edit(int? id)
        {
            Announcement announcement = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64556/");

                //Http Get
                var responseTask = client.GetAsync("api/Announcements?id=" + id.ToString());

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Announcement>();

                    announcement = readTask.Result;
                }
                return View(announcement);

            }
        }



        [HttpPost]
        public async Task<ActionResult> Edit(Announcement announcement)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64556/");

                client.DefaultRequestHeaders.Clear();
                //Defien request data  format
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Http Post
                HttpResponseMessage putTask = await client.PutAsJsonAsync<Announcement>($"api/Announcements/{announcement.Id}", announcement);

           //     var result = putTask.Result;
                if (putTask.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
             
            }

            return View(announcement);
            
        }

        public ActionResult Delete(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64556/");

                //HTTP Delete
                var deleteTask = client.DeleteAsync("api/Announcements?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }

    
}