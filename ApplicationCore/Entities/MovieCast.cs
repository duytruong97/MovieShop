using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        public int MovieId { get; set; }
        public int CastID { get; set; }
        public String Character { get; set; }

        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
    }
}
