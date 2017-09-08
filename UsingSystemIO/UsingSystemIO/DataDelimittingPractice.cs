using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingSystemIO
{
    public class DataDelimittingPractice
    {
        string path = @"c:\Data\AddressBook.txt";
        List<ContactInformation> contacts = new List<ContactInformation>();


        public void ReadingData()
        {
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');

                    ContactInformation c = new ContactInformation();
                    c.FirstName = columns[0];
                    c.LastName = columns[1];
                    c.Street1 = columns[2];
                    c.Street2 = columns[3];
                    c.City = columns[4];
                    c.State = columns[5];
                    c.ZipCode = columns[6];

                    contacts.Add(c);
                }

                foreach(var contact in contacts.OrderBy(c => c.LastName))
                {
                    Console.WriteLine("{0}, {1}", contact.LastName, contact.FirstName);
                    Console.WriteLine(contact.Street1);

                    if (!string.IsNullOrEmpty(contact.Street2))
                        Console.WriteLine(contact.Street2);

                    Console.WriteLine("{0}, {1}, {2}",
                        contact.City, contact.State, contact.ZipCode);

                    Console.WriteLine();
                }


            }
            else
            {
                Console.WriteLine("Could not find the file at {0}", path);
            }
            Console.ReadKey();
        }
    }
}
