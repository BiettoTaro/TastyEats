using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyEats.Models;

namespace TastyEats.Helpers
{
    internal class FormFiller
    {
        public static void FillCustomerFields(
            Customer customer, TextBox name, TextBox email, TextBox phone, RichTextBox address)
        {
            if (customer == null) return;
            name.Text = customer.Name;
            email.Text = customer.Email;
            phone.Text = customer.PhoneNumber;
            address.Text = customer.Address;
        }
    }
}
