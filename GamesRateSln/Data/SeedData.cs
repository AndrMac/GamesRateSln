// <copyright file="SeedData.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using GamesRateSln.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamesRateSln.Data
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceScope scope)
        {
            var cx = scope.ServiceProvider.GetRequiredService<AppDataContext>();
            cx.Database.Migrate();

            if (!cx.Games.Any())
            {
                var httpClient = scope.ServiceProvider.GetRequiredService<HttpClient>();
                var gameClient = new GameDatabase.Api.Client.Client(httpClient, "00e503cf78aa452db6d673088e710691");

                var gamelist = await gameClient.Games_listAsync(1, 100);

                if (gamelist.Results != null)
                {
                    foreach (var game in gamelist.Results)
                    {
                        cx.Add(new Game()
                        {
                            Title = game.Name,
                            ReleaseDate = game.Released.GetValueOrDefault(),
                        });
                    }
                }

                await cx.SaveChangesAsync();
            }
        }
    }
}
