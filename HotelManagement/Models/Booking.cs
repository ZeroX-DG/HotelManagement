using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Booking
    {
        [Key]
        public string ReferenceNum { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        [Required]
        [Timestamp]
        public DateTime CreatedAt { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckIn { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckOut { get; set; }
        [Required]
        public int NumGuest { get; set; }
        [Required]
        public double TotalFee { get; set; }
        [Required]
        public bool Paid { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}