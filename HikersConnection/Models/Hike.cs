using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HikersConnection.Models;
using HikersConnection.ViewModels;

namespace HikersConnection.Models
{
    public class Hike
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [ValidDate]
        [FutureDate(ErrorMessage = "The date is invalid or must be in the future.")]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        //foreign key property
        public int TrailID { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        public string Organizer { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public virtual ICollection<Hiker> Hikers { get; set; }

        //navigation property
        public virtual Trail Trail { get; set; }
        public virtual Trail Level { get; set; }
        public virtual ApplicationUser OrganizerId { get; set; }
    }
}