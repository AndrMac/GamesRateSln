// <copyright file="HomeController.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using AutoMapper;
using GamesRateSln.Data;
using GamesRateSln.Entities;
using GamesRateSln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("Home/AddRate/{id}")]
        public ViewResult AddRate(long id)
        {
            var entity = this.Context.Games.ById(id).Result;
            var model = this.Map<AddRateModel>(entity);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult AddRate(AddRateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var game = this.Context.Games.Include(x => x.Rates).ThenInclude(x => x.Person).ById(model.GameId).Result;
            if (game.Rates != null && game.Rates.Any(x => x.Person.Email == model.PersonEmail.Trim()))
            {
                this.ModelState.AddModelError("PersonEmail", "Record with same e-mail already exists");
                return this.View(model);
            }

            var rateEntity = this.Map<Rate>(model);
            var personEntity = this.Map<Person>(model);

            rateEntity.Person = personEntity;
            rateEntity.GameId = game.Id;

            this.Context.Rates.Add(rateEntity);
            this.Context.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetGamesList()
        {
            var entities = this.Context.Games;
            var models = this.Project<GameModel>(entities);

            return this.Json(models.Result);
        }

        [HttpGet]
        public JsonResult GetTop5RatedGamesList(bool asc)
        {
            var entities = this.Context.Games;
            var models = new List<GameModel>();

            if (asc)
            {
                models = this.Project<GameModel>(entities).Result.OrderBy(x => x.RateCount).Take(5).ToList();
            }
            else
            {
                models = this.Project<GameModel>(entities).Result.OrderByDescending(x => x.RateCount).Take(5).ToList();
            }

            return this.Json(models);
        }

        [HttpGet]
        public JsonResult GetRatesSummary()
        {
            var summary = this.Context.Rates.GroupBy(x => x.Value).Select(grp => new RateSummaryModel() { Rate = grp.Key, RatesCount = grp.Count() });

            return this.Json(summary);
        }

        [HttpGet]
        public JsonResult GetTop20RecentRatesList()
        {
            var entities = this.Context.Rates.Include(x => x.Game).OrderByDescending(x => x.Created).AsQueryable().Take(20);
            var models = this.Project<RecentRateModel>(entities);

            return this.Json(models.Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
