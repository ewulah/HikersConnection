using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HikersConnection.Models
{
    public class Hiker
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        //foreign key property
        public int? AgeGroupID { get; set; }

        [Display(Name = "Full Name")]
        public string  FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual AgeGroup AgeGroup { get; set; }
        public virtual IEnumerable<Models.AgeGroup> AgeGroups { get; set; }
    }
}