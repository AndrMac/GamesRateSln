// <copyright file="RecentRateModel.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace GamesRateSln.Models
{
    public class RecentRateModel
    {
        public string GameTitle { get; set; }

        public int? Value { get; set; }

        public string PersonName { get; set; }

        public string PersonEmail { get; set; }

        public string Comment { get; set; }
    }
}
