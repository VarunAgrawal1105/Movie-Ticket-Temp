using _3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieTicketBooking.Controllers
{
    
    public class MovieScreenController : ApiController
    {
        MovieDbContext db = null;
        public MovieScreenController()
        {
            this.db = new MovieDbContext();
        }
        [HttpGet]
        
        public HttpResponseMessage GetShowTime(int movieId)
        {
            var result = db.MovieScreen.Where(x => x.MovieId == movieId).Select(x => x).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
