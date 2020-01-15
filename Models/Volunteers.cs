using System;
using System.Collections.Generic;

namespace SpeakOut.Models
{
    public partial class Volunteers
    {
        public int VolunteerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string VolunteerPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
