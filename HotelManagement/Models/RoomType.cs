using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class RoomType
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public Type Type { get; set; }

        public string ImageName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int MaxGuests { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }



    }
    public enum Type
    {
        Single, TwoBedRooms, Superior
    }
}