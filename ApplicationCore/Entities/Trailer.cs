using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String TrailerUrl { get; set; }

        // foreign key
        public int MovieId { get; set; }

        // Navigation property
        public Movie Movie { get; set; }
    }
}
