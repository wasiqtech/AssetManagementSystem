﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class Response
    {
        public bool isSuccess { get; set; }
        public string data { get; set; }
        public string message { get; set; }
        public string count { get; set; }

    }
}