using _3.DataAccess;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MovieTicketBooking.Controllers
{
    public class MovieController : ApiController
    {
        MovieDbContext db = null;
        public MovieController()
        {
            this.db = new MovieDbContext();
        }

        [HttpGet]
        public HttpResponseMessage GetMovies()
        {
            var result = db.Movie.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpDelete]
        public bool DeleteMovie(int movieId)
        {
           Movie model =  db.Movie.FirstOrDefault(x => x.MovieId == movieId);
            if(model !=null)
            {
                db.Movie.Remove(model);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        [HttpPost]
        public bool AddMovies(Movie movie)
        {
            if(movie!=null)
            {
                Movie model = db.Movie.Where(x => x.MovieId == movie.MovieId).FirstOrDefault();
                if (model != null)
                {
                    model.MovieName = movie.MovieName;
                    model.ImageUrl = movie.ImageUrl;
                    model.Description = movie.Description;
                    model.MovieShows = movie.MovieShows;
                }

                else
                {
                    db.Movie.Add(movie);
                }

                db.SaveChanges();

                return true;
            }

            return false;
        }

        [Route("api/Movie/SaveFile")]
        [HttpPost]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/"+fileName);
                postedFile.SaveAs(physicalPath);
                return fileName;
            }

            catch(Exception e)
            {
                return "anonymous.png";
            }
        }

        [HttpGet]
        public HttpResponseMessage GetMovie(int MovieID)
        {
            var result = db.Movie.Where(x => x.MovieId == MovieID).FirstOrDefault();
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        

    }
}
