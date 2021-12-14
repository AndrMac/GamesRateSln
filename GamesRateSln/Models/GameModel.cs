// <copyright file="GameModel.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using GamesRateSln.Entities;
using System;
using System.Collections.Generic;

namespace GamesRateSln.Models
{
    public class GameModel : BaseModel
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Year { get; set; }

        public int RateCount { get; set; }

        public int AvrRate { get; set; }

        public ICollection<RateModel> Rates { get; set; } = new List<RateModel>();
    }
}
