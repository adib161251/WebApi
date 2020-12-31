using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        List<UserModel> users = new List<UserModel>()
        {
            new UserModel(){Id=1,UserName="Arman",Password="123",Address="dhaka"},
            new UserModel(){Id=2,UserName="Arman1",Password="1231",Address="dhaka1"},
            new UserModel(){Id=3,UserName="Arman2",Password="1232",Address="dhaka2"},
            new UserModel(){Id=4,UserName="Arman3",Password="1233",Address="dhaka3"},
            new UserModel(){Id=5,UserName="Arman4",Password="1234",Address="dhaka4"},
            new UserModel(){Id=6,UserName="Arman5",Password="1235",Address="dhaka5"},
        };

        //get:/api/User/GetData
        [Route("api/User/Getdata")]
        [HttpGet]
        public IHttpActionResult Getdata()
        {
            return Ok(users);
        }
        [Route("api/User/Getdata/{id}")]
        [HttpGet]
        public IHttpActionResult Getdata(int id)
        {
            //LINQ Query
            var result = from data in users
                         where data.Id == id
                         select data;
            //LINQ Method Syntax
            var result1 = users.Where(x => x.Id == id).ToList();
            if(result.ToList().Count != 0 )
            {
                return Ok(result);
            }
            return NotFound();

        }

        [Route("api/User/Postdata")]
        [HttpPost]
        public IHttpActionResult Postdata ([FromBody]UserModel user)
        {
            if (!ModelState.IsValid) return BadRequest("Data is invalid");


            users.Add(user);
            return Ok(users);
        }

        [Route("api/User/PostMultidata")]
        [HttpPost]
        public IHttpActionResult PostMultidata ([FromBody]List<UserModel> user)
        {
            if (!ModelState.IsValid) return BadRequest("Data is invalid");

            users.AddRange(user);
            return Ok(users);
        }

        [Route("api/User/Updatedata")]
        [HttpPut]
        public IHttpActionResult Updatedata([FromBody] UserModel user)
        {
            if (!ModelState.IsValid) return BadRequest("Data is Invalid");

            var check = users.SingleOrDefault(x => x.Id == user.Id);
            
            if(check == null)
            {
                return NotFound();
            }

            else
            {
                users.Where(x => x.Id == user.Id).ToList().ForEach((x) => {
                    x.Password = user.Password;
                    x.UserName = user.UserName;
                    x.Address = user.Address;
                });

                return Ok(users);
            }
        }
        

        [Route("api/User/Remove/{id}")]
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            //Here Single and First will through exception if there is no matching
            var removeData = users.SingleOrDefault(x => x.Id == id); 
            if(removeData == null)
            {
                return BadRequest("This Id doesn't Exists");
            }
            users.Remove(removeData);
            return Ok(users);
        }

    }
}
