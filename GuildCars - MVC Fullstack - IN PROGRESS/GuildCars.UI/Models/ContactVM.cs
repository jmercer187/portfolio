using GuildCars.UI.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    [MustEnterPhoneOrEmail(ErrorMessage = "Please enter either a phone number of email address.")]
    public class ContactVM
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }
    }
}