﻿using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    public class HomeController : Controller
    {
            [Authorize]
            public IActionResult Index()
            {
                return Content(User.Identity.Name);
            }
        
    }
}

