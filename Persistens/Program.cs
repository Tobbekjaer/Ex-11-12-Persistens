using System;
using System.IO;

namespace Persistens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initiate a new Person object 
            Person person = new Person("Anders Andersen", new DateTime(1975, 8, 24), 175.9, true, 3);

            Person[] persons = { person, person, person };


            // Initiate a new DataHandler object
            DataHandler handler = new DataHandler("Data.txt");
            // Runs the SavePersons() method in the DataHandler class with the person object above
            handler.SavePersons(persons);
            // Writing LoadPersons() to the console
            Console.WriteLine(handler.LoadPersons().ToString());

            for (int i = 0; i < persons.Length; i++) {
                Console.WriteLine(persons[i]);
            }


            Console.ReadLine(); 

        }
    }
}