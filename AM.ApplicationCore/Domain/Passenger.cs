using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Key]
        [StringLength(7,ErrorMessage= "the PassportNumber require 7 caracters")]
        public string? PassportNumber { get; set; }
        [MinLength(3, ErrorMessage = "Max length 25"),MaxLength(25,ErrorMessage ="Max length 25")]
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public FullName fullName { get; set; }
        [Display(Name = "Date of Birth"),DataType(DataType.Date)] // ay 7aja marbouta b donneés n7otou DataType 
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "invalid phone number")]
        public int TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        // prop de navigation
        public virtual List<Flight>? Flights { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }

        public override string ToString()
        {
            return "FirstName: " + fullName.FirstName + " LastName: " + fullName.LastName + " date of Birth: " + BirthDate + " Passport Number: " + PassportNumber + " Phone Number: " + TelNumber + " Email Address: " + EmailAddress;
        }


        public bool CheckProfile(string firstName, string lastName, string? email)
        {
            if (email != null)
                return fullName.FirstName == firstName && fullName.LastName == lastName &&
                EmailAddress == email;
            else
                return fullName.FirstName == firstName && fullName.LastName == lastName;
        }

        public virtual string PassengerType()
        {
            return "I am a passenger";
        }
    }
   

}