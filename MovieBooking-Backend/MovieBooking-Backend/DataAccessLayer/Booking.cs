using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime ShowTime { get; set; }
        public int NoOfTickets { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual User User { get; set; }
    }
}
