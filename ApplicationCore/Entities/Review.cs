﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public Decimal Rating { get; set; }
        public String? ReviewText { get; set; }


        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
