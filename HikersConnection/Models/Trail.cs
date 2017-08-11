using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HikersConnection.Models
{
    public enum Level
    {
        Easy, Moderate, Hard, Expert
    }

    public class Trail
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Level Level { get; set; }

        [Display(Name = "Length (in miles)")]
        // question mark = property nullable
        public double? Length { get; set; }

        [Display(Name = "Hiking Time (in hours)")]
        public double? HikingTime { get; set; }

        public bool DogFriendly { get; set; }
    }
}