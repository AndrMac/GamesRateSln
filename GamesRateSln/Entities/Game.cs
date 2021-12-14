// <copyright file="Game.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System;
using System.Collections.Generic;

namespace GamesRateSln.Entities
{
    public class Game : EntityBase
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
    }
}
