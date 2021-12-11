// <copyright file="AppDataContext.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using GamesRateSln.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesRateSln.Data
{
    public partial class AppDataContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Rate> Rates { get; set; }
    }
}
