// <copyright file="AddRateModel.cs" company="Andrejs Macko">
// Copyright (c) Andrejs Macko. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace GamesRateSln.Models
{
    public class AddRateModel
    {
        public long GameId { get; set; }

        public string GameTitle { get; set; }

        public string GameYear { get; set; }

        [Required]
        [System.ComponentModel.DefaultValue(null)]
        public int? Value { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string PersonName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string PersonEmail { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
