using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TastyEats.Helpers
{
    public static class ValidationHelper
    {

        public static string? ValidateRegistration(string email, string name, string phone, string address, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(address)
                || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
                return "Please fill in all fields.";

            if (!IsValidEmail(email))
                return "Please enter a valid email address.";

            if (password != confirmPassword)
                return "Passwords do not match. Please try again.";

            if (!IsValidPassword(password))
                return "Password must be at least 8 characters long and contain at least one special character.";

            return null; 
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;
            var passwordRegex = new Regex(@"^(?=.*\W).{8,}$");
            return passwordRegex.IsMatch(password);
        }

        public static string? ValidatePasswordChange(string oldPass, string newPass, string confPass)
        {
            if (string.IsNullOrWhiteSpace(oldPass) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confPass))
                return "To change your password, fill all password fields.";

            if (newPass != confPass)
                return "New passwords do not match.";

            if (!IsValidPassword(newPass))
                return "New password must be at least 8 characters and include a special character.";

            return null;
        }

        public static string? ValidateCardDetails(string cardName, string cardNumber, string cvv, DateTime expiry)
        {
            if (string.IsNullOrWhiteSpace(cardName) ||
                string.IsNullOrWhiteSpace(cardNumber) ||
                string.IsNullOrWhiteSpace(cvv) ||
                expiry < DateTime.Now)
                return "Please fill in all card details.";

            var cardPattern = @"^(?:\d{4}[- ]?){3}\d{4}$";
            if (!Regex.IsMatch(cardNumber, cardPattern))
                return "Card number format is invalid.";

            if (!Regex.IsMatch(cvv, @"^\d{3,4}$"))
                return "CVV must be 3 or 4 digits.";

            return null; // All valid!
        }
    }
}
