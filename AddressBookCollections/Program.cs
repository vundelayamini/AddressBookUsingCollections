using System;
using System.Collections.Generic;

namespace AddressBookCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            Program.AddcontactConsole();
        }

        public static void AddcontactConsole()
        {
            AddressBook addressBook = new AddressBook();
            int choice, choice2;
            string bookName = "Same";
            Console.WriteLine("Would You Like To \n1.Create New AddressBook \n2.Work on Same AddressBook");
            choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    addressBook.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");
                    bookName = Console.ReadLine();
                    addressBook.AddAddressBook(bookName);
                    break;
            }
            do
            {
                Console.WriteLine($"Working On {bookName} AddressBook\n");
                Console.WriteLine("Choose An Option \n1.Add New Contact \n2.Edit Existing Contact \n3.Delete A Contact \n4.View A Contact \n5.View All Contacts \n6.Exit Application\n");
                choice = Convert.ToInt32(Console.ReadLine());//convert to int
                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Enter First Name :");//take iput from the user
                        string firstName = Console.ReadLine();//store the input for firstname
                        Console.WriteLine("Enter Last Name :");//take input from user
                        string lastName = Console.ReadLine();//store the inputfor lastname
                        Console.WriteLine("Enter Address :");//take input from the user
                        string address = Console.ReadLine();//store the input for address
                        Console.WriteLine("Enter City :");//take input from the user
                        string city = Console.ReadLine();//store the input for city
                        Console.WriteLine("Enter State :");//take input from the user
                        string state = Console.ReadLine();//store the input for state
                        Console.WriteLine("Enter Email :");//take input from the user
                        string email = Console.ReadLine();//store the value for email
                        Console.WriteLine("Enter Zip :");//take input from the user
                        int zip = Convert.ToInt32(Console.ReadLine());//convert to integer
                        Console.WriteLine("Enter Phone Number :");//take input from the user
                        long phoneNumber = Convert.ToInt64(Console.ReadLine());//convert to integer
                        addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);//addcontact
                        break;

                    case 2:
                        Console.WriteLine("Enter First Name Of Contact To Edit :");//edit the contact for the firstname
                        string nameToEdit = Console.ReadLine();
                        addressBook.EditContact(nameToEdit, bookName);

                        break;
                    case 3:
                        Console.WriteLine("Enter First Name Of Contact To Delete :");//delete the contact for the sfirtname
                        string nameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(nameToDelete,bookName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name Of Contact To View :");//view contact for the firstname
                        string nameToView = Console.ReadLine();
                        addressBook.ViewContact(nameToView,bookName);
                        break;
                    case 5:
                        addressBook.ViewContact(bookName);
                        break;
                    case 6:

                        Console.WriteLine("Enter Name For New AddressBook");//new addressbook
                        string newAddressBook = Console.ReadLine();
                        addressBook.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBook> item in addressBook.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (addressBook.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Thank You For Using Address Book System.");
                        break;
                }
            } while (choice != 8);
        }

       
    }
}
           
    

