using System;
using System.Collections.Generic;

namespace Contact
{
    class Program
    {
        static void Main(string[] args)
        {
            var contactBook = new List<Tuple<string, string, string, string>>();


            var choice="";

            do
            {

                Options();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            contactBook = AddContact(contactBook);
                            break;
                        }
                    case "2":
                        {
                            contactBook = ChangeContact(contactBook);
                            break;
                        }
                    case "3":
                        {
                            contactBook = DeleteContact(contactBook);
                            break;
                        }
                    case "4":
                        {
                            SearchContactByNumber(contactBook);
                            break;
                        }
                    case "5":
                        {
                            SearchContactsByName(contactBook);
                            break;
                        }
                }

            }
            while (choice != "Exit" && choice != "exit");
        }

        static void Options()
        {
            Console.WriteLine("Press the number of the action you want to take.");
            Console.WriteLine("1. Add a contact to the contact book.");
            Console.WriteLine("2. Change a name, adress or number of an existing contact.");
            Console.WriteLine("3. Delete a contact.");
            Console.WriteLine("4. Search by phone number.");
            Console.WriteLine("5. Search by name.");
            Console.WriteLine("Exit - stop the program");
        }

        static string RemoveSpaces(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == ' ')
                {
                    number = number.Remove(i, 1);
                }
            }
            return number;
        }

        static List<Tuple<string, string, string, string>> AddContact(List<Tuple<string, string, string, string>> contacts)
        {
            Console.WriteLine("You've selected option 1, add contact, if you want to proceed type 'yes' ");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Input first name: ");
                var firstName = Console.ReadLine();
                Console.WriteLine("Input last name: ");
                var lastName = Console.ReadLine();
                Console.WriteLine("Input adress: ");
                var adress = Console.ReadLine();
                Console.WriteLine("Input phone number: ");
                var phoneNumber = Console.ReadLine();
                phoneNumber = RemoveSpaces(phoneNumber);
                Console.WriteLine("Input phone number again: ");
                var checkPhoneNumber = Console.ReadLine();
                checkPhoneNumber = RemoveSpaces(checkPhoneNumber);
                if (phoneNumber == checkPhoneNumber)
                {
                    var counter = 0;

                    for (int i = 0; i < contacts.Count; i++)
                    {

                        if (phoneNumber == contacts[i].Item4)
                        {

                            counter += 1;
                        }
                    }
                    if (counter < 1)
                    {
                        Tuple<string, string, string, string> contact = new Tuple<string, string, string, string>(firstName, lastName, adress, phoneNumber);
                        contacts.Add(contact);
                        Console.WriteLine("Successfully added contact.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("There is already a contact with that number, try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Phone numbers do not match. Try again.");
                    Console.WriteLine();
                }
            }

            return contacts;

        }

        static List<Tuple<string, string, string, string>> ChangeContact(List<Tuple<string, string, string, string>> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("You've selected option 2, change contact, if you want to proceed type 'yes' ");
                if (Console.ReadLine() == "yes")
                {
                    var contactNumber = 0;
                    Console.WriteLine("Type 'name' to change first and last name, 'adress' to change adress or 'number' to change number of a contact");
                    var choice = Console.ReadLine();
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        Console.WriteLine("Press " + (i + 1) + " if you want to change " + contacts[i].Item1 + " " + contacts[i].Item2 + "," + contacts[i].Item3 + "," + contacts[i].Item4);

                    }
                    contactNumber = int.Parse(Console.ReadLine());
                    contactNumber -= 1;
                    if (contactNumber >= 0 && contactNumber < contacts.Count)
                    {
                        List<Tuple<string, string, string, string>> newContactBook = new List<Tuple<string, string, string, string>>();
                        for (int i = 0; i < contactNumber; i++)
                        {
                            Tuple<string, string, string, string> contact = new Tuple<string, string, string, string>(contacts[i].Item1, contacts[i].Item2, contacts[i].Item3, contacts[i].Item4);
                            newContactBook.Add(contact);
                        }
                        if (choice == "name" || choice == "Name")
                        {
                            Console.WriteLine("Input new first name: ");
                            var newFirstName = Console.ReadLine();
                            Console.WriteLine("Input new last name: ");
                            var newLastName = Console.ReadLine();
                            Tuple<string, string, string, string> contact = new Tuple<string, string, string, string>(newFirstName, newLastName, contacts[contactNumber].Item3, contacts[contactNumber].Item4);
                            newContactBook.Add(contact);
                        }
                        else if (choice == "adress" || choice == "Adress")
                        {
                            Console.WriteLine("Input new adress: ");
                            var newAdress = Console.ReadLine();
                            Tuple<string, string, string, string> contact = new Tuple<string, string, string, string>(contacts[contactNumber].Item1, contacts[contactNumber].Item2, newAdress, contacts[contactNumber].Item4);
                            newContactBook.Add(contact);
                        }
                        else if (choice == "number" || choice == "Number")
                        {
                            Console.WriteLine("Input new number: ");
                            var newNumber = Console.ReadLine();
                            newNumber = RemoveSpaces(newNumber); 
                            Console.WriteLine("Input new number again: ");
                            var checkNewNumber = Console.ReadLine();
                            checkNewNumber = RemoveSpaces(checkNewNumber);
                            if (newNumber == checkNewNumber)
                            {
                                Tuple<string, string, string, string> contact = new Tuple<string, string, string, string>(contacts[contactNumber].Item1, contacts[contactNumber].Item2, contacts[contactNumber].Item3, newNumber);
                                newContactBook.Add(contact);
                                Console.WriteLine("Contact successfully changed.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Phone numbers do not match. Try again.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input. Try again.");
                            Console.WriteLine();
                        }

                        for (int i = contactNumber + 1; i < contacts.Count; i++)
                        {
                            Tuple<string, string, string, string> contact = new Tuple<string, string, string, string>(contacts[i].Item1, contacts[i].Item2, contacts[i].Item3, contacts[i].Item4);
                            newContactBook.Add(contact);
                        }
                        return newContactBook;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, no changes made.");
                        return contacts;

                    }
                }
                else
                {
                    Console.WriteLine("No changes made.");
                    return contacts;

                }

            }
            else
            {
                Console.WriteLine("Cannot change an empty contact list, add contacts and try again.");
                return contacts;
            }
        }

        static List<Tuple<string, string, string, string>> DeleteContact(List<Tuple<string, string, string, string>> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("You've selected option 3, delete contact, if you want to proceed type 'yes' ");
                if (Console.ReadLine() == "yes")
                {
                    var contactNumber = 0;
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        Console.WriteLine("Press " + (i + 1) + " if you want to delete " + contacts[i].Item1 + " " + contacts[i].Item2 + "," + contacts[i].Item3 + "," + contacts[i].Item4);

                    }
                    contactNumber = int.Parse(Console.ReadLine());
                    contactNumber -= 1;
                    if (contactNumber >= 0 && contactNumber < contacts.Count)
                    {
                        contacts.RemoveAt(contactNumber);
                        return contacts;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, no changes made.");
                        return contacts;

                    }
                }
                else
                {
                    Console.WriteLine("No changes made.");
                    return contacts;

                }
            }
            else
            {
                Console.WriteLine("Cannot delete from an empty contact list, add contacts and try again.");
                return contacts;
            }
        }

        static void SearchContactByNumber(List<Tuple<string, string, string, string>> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("Input contact's number: ");
                var number = Console.ReadLine();
                var newNumber = RemoveSpaces(number);
                var counter = 0;
                for (int i = 0; i < contacts.Count; i++)
                {
                    if (newNumber == contacts[i].Item4)
                    {
                        Console.WriteLine("Contact with the number " + number + " is " + contacts[i].Item1 + " " + contacts[i].Item2 + ", " + contacts[i].Item3);
                        counter += 1;
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("No contact exists with the number " + number);
                }
            }
            else
            {
                Console.WriteLine("Cannot search from an empty list, add some contacts first.");
            }
        }

        static void SearchContactsByName(List<Tuple<string, string, string, string>> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("Input contact's name: ");
                var name = Console.ReadLine();
                var lastNames = new List<string>();
                var firstNames = new List<string>();
                for (int i = 0; i < contacts.Count; i++)
                {
                    if (contacts[i].Item2.StartsWith(name))
                    {
                        lastNames.Add(contacts[i].Item2);
                    }
                }
                for (int i = 0; i < contacts.Count; i++)
                {
                    if (contacts[i].Item1.StartsWith(name))
                    {
                        firstNames.Add(contacts[i].Item1);
                    }
                }
                lastNames.Sort();
                firstNames.Sort();
                for (int i = 0; i < lastNames.Count; i++)
                {
                    for (int o = 0; o < contacts.Count; o++)
                        if (lastNames[i] == contacts[o].Item2)
                        {
                            Console.WriteLine("Name :" + contacts[o].Item1 + " " + contacts[o].Item2 + ", adress: " + contacts[o].Item3 + ", number: " + contacts[o].Item4);
                        }
                    for (int o = contacts.Count-1; o >=0; o--)
                        if (lastNames[i] == contacts[o].Item2)
                        {
                            contacts.RemoveAt(o);
                        }
                }
                for (int i = 0; i < firstNames.Count; i++)
                {
                    for (int o = 0; o < contacts.Count; o++)
                        if (firstNames[i] == contacts[o].Item1)
                        {
                            Console.WriteLine("Name :" + contacts[o].Item1 + " " + contacts[o].Item2 + ", adress: " + contacts[o].Item3 + ", number: " + contacts[o].Item4);
                        }
                    for (int o = contacts.Count - 1; o >= 0; o--)
                        if (firstNames[i] == contacts[o].Item1)
                        {
                            contacts.RemoveAt(o);
                        }
                }
            }
            else
            {
                Console.WriteLine("Cannot search from an empty list, add some contacts first.");
            }
        }
    }
}
