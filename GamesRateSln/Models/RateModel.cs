// <copyright file="RateModel.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRateSln.Models
{
    public class RateModel : BaseModel
    {
        public int Value { get; set; }

        public GameModel Game { get; set; }

        public PersonModel Person { get; set; }

        public string Comment { get; set; }
    }
}
