using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string ImageUrl { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }

        public IList<MovieScreen> MovieShows { get; set; }
        
    }
}
