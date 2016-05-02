﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClashOfTheCharacters.Models
{
    public class Travel
    {
        public int Id { get; set; }

        public DateTimeOffset ArrivalTime { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int LandId { get; set; }
        public virtual Land Land { get; set; }
    }
}