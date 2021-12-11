// <copyright file="Person.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System.Collections.Generic;

namespace GamesRateSln.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Rate> Rates { get; set; }
    }
}
