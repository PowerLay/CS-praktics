using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Int32;

namespace Serialize_People
{
    // A simple program that accepts a name, year, month date,
    // creates a Person object from that information, 
    // and then displays that person's age on the console.
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // If they provide no arguments, display the last person
                Person p = Deserialize();
                Console.WriteLine(p.ToString());
            }
            else
            {
                try
                {
                    if (args.Length != 4)
                    {
                        throw new ArgumentException("You must provide four arguments.");
                    }

                    DateTime dob = new DateTime(Parse(args[1]), Parse(args[2]), Parse(args[3]));
                    Person p = new Person(args[0], dob);
                    Console.WriteLine(p.ToString());

                    Serialize(p);
                }
                catch (Exception ex)
                {
                    DisplayUsageInformation(ex.Message);
                }
            }
        }

        private static void DisplayUsageInformation(string message)
        {
            Console.WriteLine("\nERROR: Invalid parameters. " + message);
            Console.WriteLine("\nSerialize_People \"Name\" Year Month Date");
            Console.WriteLine("\nFor example:\nSerialize_People \"Tony\" 1922 11 22");
            Console.WriteLine("\nOr, run the command with no arguments to display that previous person.");
        }

        private static void Serialize(Person sp)
        {
            // TODO: Serialize sp object
            // Create file to save the data to
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, sp);

            // Close the file
            fs.Close();

        }

        private static Person Deserialize()
        {
            Person dsp = new Person();

            // ��������� ���� ��� ������ ������	
            FileStream fs = new FileStream("Person.Dat", FileMode.Open);
            // ������� ������ BinaryFormatter ��� ���������� ��������������
            BinaryFormatter bf = new BinaryFormatter();
            // ���������� ������ BinaryFormatter ��� �������������� ������ �� �����
            dsp = (Person)bf.Deserialize(fs);
            // ��������� ���� fs.Close();

            return dsp;

        }
    }
}
