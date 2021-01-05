<<<<<<< HEAD
﻿using Newtonsoft.Json.Linq;
using System;
=======
﻿using System;
>>>>>>> 9a8051f81ce98f7f6562c93f93c8ff627c4b9018
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
<<<<<<< HEAD

        public ActionResult Details(int? id)
        {
            if (id == null) return RedirectToRoute("/Read/Read");
            List<UserModel> user = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49418/api/");
                var responseTask = client.GetAsync("User/Getdata/" + id);
                responseTask.Wait();

                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<UserModel>>();
                    readTask.Wait();

                    user = readTask.Result;
                }
                else
                {
                    return Content("Error While getting data"+ result.StatusCode);
                }

            }
            return View("Details",user);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult ProcessCreate(UserModel user)
        {
            List<UserModel> users = new List<UserModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49418/api/");
                
                //this serializes model data into json formet
                if(user.Id <= 0)
                {
                    var postTalk = client.PostAsJsonAsync<UserModel>("User/Postdata", user);
                    postTalk.Wait();

                    var result = postTalk.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //Here Json data gets deserialize into List<model> data
                        var readTask = result.Content.ReadAsAsync<List<UserModel>>();
                        readTask.Wait();

                        users = readTask.Result;
                    }
                    else
                    {
                        return Content("Problem while posting" + result.StatusCode);
                    }
                }

                else
                {
                    var putTalk = client.PutAsJsonAsync<UserModel>("User/Updatedata", user);
                    putTalk.Wait();

                    var result = putTalk.Result;
                    if(result.IsSuccessStatusCode)
                    {
                        var updateData = result.Content.ReadAsAsync<List<UserModel>>();
                        updateData.Wait();

                        users = updateData.Result;
                    }
                    else
                    {
                        return Content("Problem While Updating" + result.StatusCode);
                    }
                }
               
            }
            return View("Read",users);
        }


        public ActionResult Update(int id)
        {
            List<UserModel> user = new List<UserModel>();
            UserModel data = new UserModel();
            //JObject json = new JObject();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49418/api/");
                var responseTask = client.GetAsync("User/Getdata/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readdata =result.Content.ReadAsAsync<List<UserModel>>();
                    readdata.Wait();

                    user = readdata.Result;
                    foreach (UserModel i in user)
                    {
                        data.Id = i.Id;
                        data.UserName = i.UserName;
                        data.Password = i.Password;
                        data.Address = i.Address;
                    }
                }
                else
                {
                    return Content("Error with Uri" + result.StatusCode);
                }
            }
                return View("Create",data);
        }

        public ActionResult Multi()
        {
            return View("Multi");
        }

        public ActionResult backup()
        {
            return View("backup");
        }


=======
>>>>>>> 9a8051f81ce98f7f6562c93f93c8ff627c4b9018
    }
}