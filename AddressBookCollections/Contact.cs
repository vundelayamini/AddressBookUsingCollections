﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookCollections
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public Contact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Email = email;
            Zip = zip;
            PhoneNumber = phoneNumber;
        }



        public override bool Equals(object obj)
        {
            Contact contact = (Contact)obj;
            if (contact == null)
                return false;
            else
                return FirstName.Equals(contact.FirstName) && LastName.Equals(contact.LastName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
