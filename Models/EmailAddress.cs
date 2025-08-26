using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSummer25.Models
{
    public class EmailAddress
    {
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    !value.Any(char.IsUpper) ||
                    !value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Email must contain at least one uppercase letter and one number.");
                }
                email = value;
            }
        }

        public EmailAddress(string email)
        {
            Email = email; // Use the property setter to validate and assign
        }

        public static implicit operator string(EmailAddress v)
        {
            throw new NotImplementedException();
        }
    }
}
