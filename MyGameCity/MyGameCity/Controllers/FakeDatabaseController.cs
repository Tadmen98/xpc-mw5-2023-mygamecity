﻿using MyGameCity.Services;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DataModel;
using Bogus;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDatabaseController : ControllerBase
    {
        //public static List<Games> ModelDatabase;
        [HttpGet]
        public void CreatDatabase() => FakeDatabaseService.CreateDatabase();
    }
}