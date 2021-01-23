﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib.Domain.Utilities
{
    public class CustomJsonResult
    {
        public CustomJsonResult()
        {
            StatusCode = 400;
        }

        public string Message { get; set; }
        public string access_token { get; set; }
        public object Result { get; set; }

        public object Optional { get; set; }
        public int StatusCode { get; set; }
    }
}