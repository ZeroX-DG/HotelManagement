using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Room
    {
        public string ID { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual Booking Booking { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public string RoomNum { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]
        public bool Available { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
    public enum Status {
        VacantClean, VacantDirty, OccupiedClean, OccupiedService, OnMaintenance  
    }
}