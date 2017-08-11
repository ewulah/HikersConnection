using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HikersConnection.Models
{
    public class AgeGroup
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Group { get; set; }
    }
}