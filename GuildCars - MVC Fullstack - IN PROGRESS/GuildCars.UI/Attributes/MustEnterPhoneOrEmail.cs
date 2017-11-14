using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Attributes
{
    public class MustEnterPhoneOrEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ContactVM)
            {
                ContactVM model = (ContactVM)value;

                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Phone))
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}