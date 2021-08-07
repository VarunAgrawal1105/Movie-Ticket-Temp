using _3.DataAccess;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieTicketBooking.Controllers
{
    public class UserController : ApiController
    {
        MovieDbContext db = null;
        public UserController()
        {
            this.db = new MovieDbContext();
        }
        [HttpGet]
        public HttpResponseMessage Login(string email, string password)
        {
            if (email != null && password != null)
            {
                var model = db.User.Where(a => a.Email == email && a.Password==password).FirstOrDefault();
                if (model != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid");
        }
        [HttpPost]
        public bool SignUp(User user)
        {
            var validate = db.User.Where(a => a.Email == user.Email).FirstOrDefault();
            if(user!=null  && validate==null)
            {
                db.User.Add(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //public bool MovieBooking(Booking booking)
        //{
        //    var book = db.User.Where(a => a.UserId == booking.UserId).FirstOrDefault();

        //}

    }
}
