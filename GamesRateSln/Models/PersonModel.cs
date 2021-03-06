// <copyright file="PersonModel.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRateSln.Models
{
    public class PersonModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<RateModel> Rates { get; set; }
    }
}
