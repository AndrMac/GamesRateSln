// <copyright file="HomeController.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using AutoMapper;
using GamesRateSln.Data;
using GamesRateSln.Extensions;
using GamesRateSln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace GamesRateSln.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(ILogger<HomeController> logger, AppDataContext cx, IMapper mapper)
            : base(logger, cx, mapper)
        {
            this.Logger = logger;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpGet]
        [Route("Home/AddRate/{id}")]
        public PartialViewResult AddRate(long id)
        {
            var entity = this.Context.Games.ById(id).Result;
            var model = this.Map<AddRateModel>(entity);
            return this.PartialView(model);
        }

        [HttpPost]
        [Route("Home/AddRate")]
        public PartialViewResult AddRate(AddRateModel model)
        {
            return this.PartialView(model);
        }

        [HttpGet]
        public JsonResult GetGamesList()
        {
            var entities = this.Context.Games;
            var models = this.Project<GameModel>(entities).Result;
            return this.Json(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
