using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;

namespace Persistens
{
    public class DataHandler
    {
        // Private fields
        private string dataFileName;

        // Property only with a getter - the attribute gets an assigned value from the constructor
        public string DataFileName
        {
            get { return dataFileName; }
        }

        // Constructor with parameter to initialize the DataFileName property
        public DataHandler(string dataFileName) 
        { 
            this.dataFileName = dataFileName;
        }

        // SavePerson method stores data from the parameter (Person object) to the text file
        public void SavePerson(Person person)
        {
            // Creates an instance of a StreamWriter method
            StreamWriter writer = new StreamWriter(dataFileName);

            // Writes to the file using the MakeTitle method to format the Person object info to the appropiate string
            writer.WriteLine(person.MakeTitle());

            // Closes the stream so that the information is stored in the text file
            writer.Close();
        }


        // SavePersons() saves persons to an array and stores them
        public void SavePersons(Person[] persons)
        {

            // Creates an instance of a StreamWriter method
            StreamWriter writer = new StreamWriter(dataFileName);

                    // string[] savePersons = new Array[];

                    foreach (Person p in persons) {

                        // Writes to the file using the MakeTitle method to format the Person object info to the appropiate string
                        writer.WriteLine(p.MakeTitle());
                        
                    }

                writer.Close();

        }


        // LoadPerson method reads from a tekstfile and stores the data in a new Person object
        public Person LoadPerson()
        {
            // Creates an instance of the StreamReader method
            StreamReader reader = new StreamReader(dataFileName);

            // Creates a string 
            // Reads the file 'dataFileName' to the end
            string readFile = reader.ReadToEnd();

            // Use Split() method to split the string into pieces and save it to the array elements
            string[] elements = readFile.Split(';');

            // Use Parse() to parse the type from the string
            string name = elements[0];
            DateTime birthDate = DateTime.Parse(elements[1]);
            double height = double.Parse(elements[2]);
            bool isMarried = bool.Parse(elements[3]);
            int noOfChildren = int.Parse(elements[4]);

            // Close the reader
            reader.Close();

            // Save your splits in a new Person object 
            Person newPerson = new Person(name, birthDate, height, isMarried, noOfChildren);

            return newPerson; 
        }


        public Person[] LoadPersons()
        {
            // Creating an array to hold persons
            Person[] arrayOfPersons = new Person[100];

            // Creates an instance of a StreamWriter method
            StreamReader reader = new StreamReader(dataFileName);
                
                // Creates an instance of the StreamReader method
                string readFile = " ";

                // Reads each line until file is empty
                while ((readFile = reader.ReadLine()) != null) {


                    // Use Split() method to split the string into pieces and save it to the array elements
                    string[] elements = readFile.Split(';');

                    // Use Parse() to parse the type from the string
                    string name = elements[0];
                    DateTime birthDate = DateTime.Parse(elements[1]);
                    double height = double.Parse(elements[2]);
                    bool isMarried = bool.Parse(elements[3]);
                    int noOfChildren = int.Parse(elements[4]);

                    // Save your splits in a new Person object 
                    Person newPerson = new Person(name, birthDate, height, isMarried, noOfChildren);

                    // Puts the person from the array in the first empty spot
                    for (int i = 0; i < arrayOfPersons.Length; i++) {
                        if (arrayOfPersons[i] == null) {
                            arrayOfPersons[i] = newPerson;
                            break;
                        }
                    }
                   

            }
      
            return arrayOfPersons;

        }

    }
}
