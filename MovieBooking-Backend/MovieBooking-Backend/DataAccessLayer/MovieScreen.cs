using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MovieScreen
    {
        [Key]
        public int ScreenId { get; set; }
        public int MovieId { get; set; }
        public int Tickets { get; set; } = 100;
        public DateTime ShowTime { get; set; }
        public int Price { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

    }
}
