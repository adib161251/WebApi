using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public UserModel()
        {
            this.Id = 0;
            this.UserName = "Nothing";
            this.Password = "Nothing";
            this.Address = "Nothing";
        }
    }
}