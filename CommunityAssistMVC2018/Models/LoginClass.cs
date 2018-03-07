﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistMVC2018.Models
{
    public class LoginClass
    {
        public LoginClass() { }
        public LoginClass(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}