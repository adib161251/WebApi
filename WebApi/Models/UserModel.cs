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
<<<<<<< HEAD
            this.Id = -1;
=======
            this.Id = 0;
>>>>>>> 9a8051f81ce98f7f6562c93f93c8ff627c4b9018
            this.UserName = "Nothing";
            this.Password = "Nothing";
            this.Address = "Nothing";
        }
    }
}