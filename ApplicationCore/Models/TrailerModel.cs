using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class TrailerModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public String TrailerName { get; set; }
        public String TrailerUrl { get; set; }
    }
}
