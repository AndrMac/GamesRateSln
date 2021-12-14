// <copyright file="Rate.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace GamesRateSln.Entities
{
    public class Rate : EntityBase
    {
        public int Value { get; set; }

        public long GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public Person Person { get; set; }

        public string Comment { get; set; }
    }
}
