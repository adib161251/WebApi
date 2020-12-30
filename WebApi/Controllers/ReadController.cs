using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
        public ActionResult Read()
        {
            List<UserModel> users = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49418/api/");

                //geting data 
                var responseTask = client.GetAsync("User/Getdata");
                // responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<UserModel>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else
                {
                    users = null;
                }
            }
            return View("Read", users);
        }
    }
}