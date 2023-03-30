using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistens
{
    public class Person
    {
        // Fields --> private fields, has public properties below 
        // Private fields is written in camelCase
        private string name;
        private DateTime birthDate;
        private double height;
        private bool isMarried;
        private int noOfChildren;

        // Creating properties for the private fields above
        // Properties has a getter and setter
        public string Name {

            get { return name; }

            // Makes sure that the name of a person is not null
            set
            {
                if (string.IsNullOrEmpty(value)) {
                    throw new Exception("Invalid name: Name must contain at least one character...");
                }
                else { name = value; }
            }

        } 
        
        public DateTime BirthDate { 

            get { return birthDate; }

            // Makes sure that a persons birthdate is not before January 1st 1900
            set
            {
                DateTime checkDate = new DateTime(1900, 01, 01);
                if (value < checkDate) {
                    throw new Exception("Invalid name: Name must contain at least one character...");
                }
                else { birthDate = value; }

            }
        }

        public double Height
        {
            get { return height; }

            // Makes sure that the height is greater than 0
            set
            {
                if (value < 0) {
                    throw new Exception("Invalid name: Name must contain at least one character...");
                }
                else { height = value; }
            }
                
        }

        public bool IsMarried { 
            get { return isMarried; }
            set { isMarried = value; }
        }

        public int NoOfChildren
        {
            get { return  noOfChildren; }

            // Makes sure a person can't have a negative amount of children
            set{
                if (value < 0) {
                    throw new Exception("Invalid name: Name must contain at least one character...");
                }
                else { noOfChildren = value; }
                
            }
        }


        // Creating a constructor
        public Person(string name, DateTime birthDate, double height, bool isMarried, int noOfChildren) {

            // Using 'this' keyword to assign parameter values to our private field values
            // Throw an exception if the constructor receives invalid parameter input

            // name
            if (string.IsNullOrEmpty(name)) {
                throw new Exception("Invalid name: Name must contain at least one character...");
            }
            else { this.name = name; }

            // birthDate
            DateTime checkDate = new DateTime(1900, 01, 01);
            if (birthDate < checkDate) {
                throw new Exception("Invalid name: Name must contain at least one character...");
            }
            else { this.birthDate = birthDate; }

            // height
            if (height < 0) {
                throw new Exception("Invalid name: Name must contain at least one character...");
            }
            else { this.height = height; }
            
            // isMarried
            this.isMarried = isMarried;

            // noOfChildren
            if (noOfChildren < 0) {
                throw new Exception("Invalid name: Name must contain at least one character...");
            }
            else { this.noOfChildren = noOfChildren; }
            
        }

        // Constructor overloading: if a person has no children --> set default value = 0
        public Person(string name, DateTime birthDate, double height, bool isMarried)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.height = height;
            this.isMarried = isMarried;
            noOfChildren = 0;
        }

        // Create MakeTitle() method that returns a formatted string
        public string MakeTitle()
        {   
            // Formatterer hvordan title stringen skal printes
                // Angiver formatteringen på birthday 
            string title = $"{name};{birthDate.ToString("dd-MM-yyyy HH':'mm':'ss")};" +
                // Ændrer navnekulturen til Europæisk, hvor decimaler er angivet med komma ','
                $"{height.ToString("0.0", new CultureInfo("da-DK"))};{isMarried};{noOfChildren}";
            return title;
        }

    }
}
