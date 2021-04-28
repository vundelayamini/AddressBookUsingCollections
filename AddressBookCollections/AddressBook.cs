using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookCollections
{
    class AddressBook : IContact
    {
        private Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();//create dictionary
        private Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();//create dictionary for addressbookdictionary        
        private Dictionary<Contact, string> cityDictionary = new Dictionary<Contact, string>();//create dictionary for city
        private Dictionary<Contact, string> stateDictionary = new Dictionary<Contact, string>();//create dicionay for state
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber, string bookName)//constructor
        {


            Contact contact = new Contact(firstName, lastName, address, city, state, email, zip, phoneNumber);
            addressBookDictionary[bookName].addressBook.Add(contact.FirstName + " " + contact.LastName, contact);
            Console.WriteLine("\nAdded Succesfully. \n");

        }
        public void ViewContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("First Name : " + item.Value.FirstName);
                    Console.WriteLine("Last Name : " + item.Value.LastName);
                    Console.WriteLine("Address : " + item.Value.Address);
                    Console.WriteLine("City : " + item.Value.City);
                    Console.WriteLine("State : " + item.Value.State);
                    Console.WriteLine("Email : " + item.Value.Email);
                    Console.WriteLine("Zip : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
                }
            }


        }
        public void ViewContact(string bookName)//Add New Contact details
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                Console.WriteLine("First Name : " + item.Value.FirstName);
                Console.WriteLine("Last Name : " + item.Value.LastName);
                Console.WriteLine("Address : " + item.Value.Address);
                Console.WriteLine("City : " + item.Value.City);
                Console.WriteLine("State : " + item.Value.State);
                Console.WriteLine("Email : " + item.Value.Email);
                Console.WriteLine("Zip : " + item.Value.Zip);
                Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
            }
        }
        public void EditContact(string name, string bookName)//Edit the existing contact details
        {
            {
                foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
                {
                    if (item.Key.Equals(name))//the key value equals the name
                    {
                        Console.WriteLine("Choose What to Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");//print the values
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)//using switch case
                        {
                            case 1:
                                Console.WriteLine("Enter New First Name :");//Take input from the user
                                item.Value.FirstName = Console.ReadLine();//store the value
                                break;
                            case 2:
                                Console.WriteLine("Enter New Last Name :");
                                item.Value.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter New Address :");
                                item.Value.Address = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Enter New City :");
                                item.Value.City = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Enter New State :");
                                item.Value.State = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Enter New Email :");
                                item.Value.Email = Console.ReadLine();
                                break;
                            case 7:
                                Console.WriteLine("Enter New Zip :");
                                item.Value.Zip = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 8:
                                Console.WriteLine("Enter New Phone Number :");
                                item.Value.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                                break;
                        }
                        Console.WriteLine("\nEdited Successfully.\n");
                    }
                }
            }
        }
        public void DeleteContact(string name, string bookName)//Delete a person using name
        {
            if (addressBookDictionary[bookName].addressBook.ContainsKey(name))
            {
                addressBookDictionary[bookName].addressBook.Remove(name);
                Console.WriteLine("\nDeleted Succesfully.\n");
            }
            else
            {
                Console.WriteLine("\nNot Found, Try Again.\n");
            }
        }
        public void AddAddressBook(string bookName)//Address book add bookname
        {
            AddressBook addressBook = new AddressBook();
            addressBookDictionary.Add(bookName, addressBook);
            Console.WriteLine("AddressBook Created.");
        }
        public Dictionary<string, AddressBook> GetAddressBook()//using dictionary
        {
            return addressBookDictionary;
        }
        public List<Contact> GetListOfDictctionaryKeys(string bookName)
        {

            List<Contact> book = new List<Contact>();
            foreach (var value in addressBookDictionary[bookName].addressBook.Values)
            {
                book.Add(value);
            }
            return book;
        }

        public bool CheckDuplicateEntry(Contact c, string bookName)//check the duplicate entry
        {
            List<Contact> book = GetListOfDictctionaryKeys(bookName);
            if (book.Any(b => b.Equals(c)))
            {
                Console.WriteLine("Name already Exists.");
                return true;
            }
            return false;
        }
    
    public List<Contact> GetListOfDictctionaryKeys2(Dictionary<string, Contact> d)
    {
        List<Contact> book = new List<Contact>();
        foreach (var value in d.Values)
        {
            book.Add(value);
        }
        return book;
    }
    public void SearchPersonByCity(string city)//search a person in city
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressBook);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void SearchPersonByState(string state)//Search a person in state
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                List<Contact> contactList = GetListOfDictctionaryKeys2(addressbookobj.addressBook);
                foreach (Contact contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }


        }
    }
}
