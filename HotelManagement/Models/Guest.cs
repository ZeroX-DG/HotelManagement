using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Guest
    {

        [Key]
        public string ID { get; set; }
        
        public int NumChildren { get; set; }
        public int NumAdults { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual Company Company { get; set; }

    }
}