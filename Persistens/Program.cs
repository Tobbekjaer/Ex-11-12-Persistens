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
            // Runs the SavePerson() method in the DataHandler class with the person object above
            handler.SavePerson(person);
            // Writing LoadPerson() to the console (1 person)
            Person newPerson = handler.LoadPerson();
            Console.WriteLine(newPerson.MakeTitle());

            // Writing the persons array to the console (3 persons)
            for (int i = 0; i < persons.Length; i++) {
                Person printPerson = persons[i];
                Console.WriteLine(printPerson.MakeTitle());
        }

            Console.ReadLine(); 

        }
    }
}